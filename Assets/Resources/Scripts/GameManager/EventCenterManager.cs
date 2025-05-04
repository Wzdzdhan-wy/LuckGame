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
    //移除监听器

    public void RemoveEventListener(GameController eventName, Action listener)
    {
        if(CheckRemoveEventListener(eventName, listener))
        {
            eventsDict[eventName] = (Action)Delegate.Remove((Action)eventsDict[eventName], listener);
        }
    }
   //移除所有监听器
    public void RemoveAllEventListener()
    {
        eventsDict.Clear();
    }   

}
