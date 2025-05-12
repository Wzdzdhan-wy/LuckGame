using LuckGame;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
// 事件中心管理器
public class EventCenterManager : SingleInstanceBase<EventCenterManager>
{
    private EventCenterManager() { }

    // 
    // 事件中心
    //创建字典，用来存储事件和监听器的关系
    Dictionary<GameController, Delegate> eventsDict = new();

    //检测是否存在某个事件
    private void CheckAddEventListener(GameController eventName, Action listener)
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
    private bool CheckRemoveEventListener(GameController eventName, Delegate listener)
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
    public void AddEventListener(GameController eventName, Action action)
    {
        CheckAddEventListener(eventName, action);
        eventsDict[eventName] = (Action)Delegate.Combine((Action)eventsDict[eventName], action);
    }
    // 带参的事件注册
    public void AddEventListener<T>(GameController eventName, Action<T> listener)
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
    public void AddEventListener<T1, T2>(GameController eventName, Action<T1, T2> listener)
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

    public void TriggerEvent(GameController eventName)
    {
        if(eventsDict.TryGetValue(eventName,out var targetDelegate))
        {
            if(targetDelegate == null)
                return;
            Delegate[] invocaltionList = targetDelegate.GetInvocationList();
            for (int i = 0; i < invocaltionList.Length; i++)
            {
                if (invocaltionList[i].GetType() != typeof(Action))
                    throw new Exception("事件类型不一致"+eventName.ToString());
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
    public void TriggerEvent<T>(GameController eventName, T arg)
    {
        if (eventsDict.TryGetValue(eventName, out var targetDelegate))
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
    public void TriggerEvent<T1, T2>(GameController eventName, T1 arg1, T2 arg2)
    {
        if (eventsDict.TryGetValue(eventName, out var targetDelegate))
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
    //移除监听器

    public void RemoveEventListener(GameController eventName, Action listener)
    {
        if(CheckRemoveEventListener(eventName, listener))
        {
            eventsDict[eventName] = (Action)Delegate.Remove((Action)eventsDict[eventName], listener);
        }
    }
    //带参的移除监听器
    public void RemoveEventListener<T>(GameController eventName, Action<T> listener)
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
    public void RemoveEventListener<T1, T2>(GameController eventName, Action<T1, T2> listener)
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
