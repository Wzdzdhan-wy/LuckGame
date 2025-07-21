using LuckGame;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
// 事件中心管理器
//继承单例框架，实现单例模式
//提供无参，1个参数，2个参数的事件注册，发送，移除监听器功能 （一般推荐最多16个带参事件）。
//提供异步触发事件功能，并且线程安全，防止多线程访问时出现问题。
public class EventCenterManager : SingleInstanceBase<EventCenterManager>
{
    private EventCenterManager() { }

    
    // 事件中心
    //创建字典，用来存储事件和监听器的关系
    Dictionary<Enum, Delegate> eventsDict = new();

    // 线程安全的锁对象
    private readonly object lockObj = new object();

    //检测是否存在某个事件
    private void CheckAddEventListener(Enum eventName, Action listener)
    {
        if (!eventsDict.ContainsKey(eventName))
        {
            eventsDict.Add(eventName, null);
            Delegate temp = eventsDict[eventName];
            if(temp != null && temp.GetType() != listener.GetType())
            {
                throw new Exception("事件已存在，但类型不一致"+temp.GetType()+listener.GetType());
            }
        }
    }
    private bool CheckRemoveEventListener(Enum eventName, Delegate listener)
    {
        bool resutl = false;
        if (!eventsDict.ContainsKey(eventName))
            resutl =  false;
        else
        {
            Delegate temp = eventsDict[eventName];
            if (temp != null && temp.GetType() != listener.GetType())
            {
                throw new Exception("事件已存在，但类型不一致" + temp.GetType() + listener.GetType());
            }
            return true;
        }
    
        return resutl;
    }
    //《事件注册》
    public void AddEventListener(Enum eventName, Action action)
    {
        CheckAddEventListener(eventName, action);
        eventsDict[eventName] = (Action)Delegate.Combine((Action)eventsDict[eventName], action);
    }
    // 带参的事件注册
    public void AddEventListener<T>(Enum eventName, Action<T> listener)
    {
        // 检查事件是否存在且类型匹配
        if (!eventsDict.ContainsKey(eventName))
        {
            eventsDict.Add(eventName, null);
        }

        Delegate existingDelegate = eventsDict[eventName];
        if (existingDelegate != null && existingDelegate.GetType() != typeof(Action<T>))
        {
            throw new Exception($"事件 {eventName} 类型不匹配。当前类型：{existingDelegate.GetType()}，新类型：{typeof(Action<T>)}");
        }

        // 合并委托
        eventsDict[eventName] = (Action<T>)Delegate.Combine((Action<T>)existingDelegate, listener);
    }
    //带2个参数的事件注册
    public void AddEventListener<T1, T2>(Enum eventName, Action<T1, T2> listener)
    {
        if (!eventsDict.ContainsKey(eventName))
        {
            eventsDict.Add(eventName, null);
        }

        Delegate existingDelegate = eventsDict[eventName];
        if (existingDelegate != null && existingDelegate.GetType() != typeof(Action<T1, T2>))
        {
            throw new Exception($"事件 {eventName} 类型不匹配。当前类型：{existingDelegate.GetType()}，新类型：{typeof(Action<T1, T2>)}");
        }

        eventsDict[eventName] = (Action<T1, T2>)Delegate.Combine((Action<T1, T2>)existingDelegate, listener);
    }

    //发送命令

    public void TriggerEvent(Enum eventName)
    {
        if (eventsDict.TryGetValue(eventName, out Delegate targetDelegate))
        {
            if (targetDelegate == null)
                return;
            Delegate[] invocaltionList = targetDelegate.GetInvocationList();
            for (int i = 0; i < invocaltionList.Length; i++)
            {
                if (invocaltionList[i].GetType() != typeof(Action))
                    throw new Exception("事件类型不一致" + eventName.ToString());
                Action action = (Action)invocaltionList[i];
                try
                {
                    action();
                }
                catch (Exception e)
                {
                    Debug.LogError(e.ToString());
                }
            }
        }
    }
    //带参的事件发送
    public void TriggerEvent<T>(Enum eventName, T arg)
    {
        if (eventsDict.TryGetValue(eventName, out Delegate targetDelegate))
        {
            Action<T> action = targetDelegate as Action<T>;
            if (action != null)
            {
                action.Invoke(arg); // 触发所有监听器
            }
            else
            {
                Debug.LogError($"触发事件 {eventName} 失败：类型不匹配，预期 {typeof(Action<T>)}");
            }
        }
    }
    //带2个参数的事件发送
    public void TriggerEvent<T1, T2>(Enum eventName, T1 arg1, T2 arg2)
    {

        if (eventsDict.TryGetValue(eventName, out Delegate targetDelegate))
        {
            Action<T1, T2> action = targetDelegate as Action<T1, T2>;
            if (action != null)
            {
                action.Invoke(arg1, arg2);
            }
            else
            {
                Debug.LogError($"触发事件 {eventName} 失败：类型不匹配");
            }
        }
    }

    //异步触发事件
    public async Task TriggerEventAsync(Enum eventName)
    {
        Delegate eventDelegate;

        lock (lockObj)
        {
            if (!eventsDict.TryGetValue(eventName, out eventDelegate)) return;
        }

        if (eventDelegate is Action action)
        {
            await Task.Run(() => action.Invoke());
        }
    }
    //异步带参触发事件
    public async Task TriggerEventAsync<T>(Enum eventName, T arg)
    {
        Delegate eventDelegate;

        lock (lockObj)
        {
            if (!eventsDict.TryGetValue(eventName, out eventDelegate)) return;
        }

        if (eventDelegate is Action<T> action)
        {
            await Task.Run(() => action.Invoke(arg));
        }
    }
    //异步带2个参数触发事件
    public async Task TriggerEventAsync<T1, T2>(Enum eventName, T1 arg1, T2 arg2)
    {
        Delegate eventDelegate;

        lock (lockObj)
        {
            if (!eventsDict.TryGetValue(eventName, out eventDelegate)) return;
        }

        if (eventDelegate is Action<T1, T2> action)
        {
            await Task.Run(() => action.Invoke(arg1, arg2));
        }
    }

    //移除监听器
    public void RemoveEventListener(Enum eventName, Action listener)
    {
        if(CheckRemoveEventListener(eventName, listener))
        {
            eventsDict[eventName] = (Action)Delegate.Remove((Action)eventsDict[eventName], listener);
        }
    }
    //带参的移除监听器
    public void RemoveEventListener<T>(Enum eventName, Action<T> listener)
    {
        if (eventsDict.TryGetValue(eventName, out var existingDelegate))
        {
            if (existingDelegate is Action<T> action)
            {
                action = (Action<T>)Delegate.Remove(action, listener);
                eventsDict[eventName] = action;
            }
            else
            {
                Debug.LogError($"移除事件 {eventName} 失败：类型不匹配");
            }
        }
    }
    //带2个参数的移除监听器
    public void RemoveEventListener<T1, T2>(Enum eventName, Action<T1, T2> listener)
    {
        if (eventsDict.TryGetValue(eventName, out var existingDelegate))
        {
            if (existingDelegate is Action<T1, T2> action)
            {
                action = (Action<T1, T2>)Delegate.Remove(action, listener);
                eventsDict[eventName] = action;
            }
            else
            {
                Debug.LogError($"移除事件 {eventName} 失败：类型不匹配");
            }
        }
    }
    //移除所有监听器
    public void RemoveAllEventListener()
    {
        eventsDict.Clear();
    }   

}
