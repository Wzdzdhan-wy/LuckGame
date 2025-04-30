using LuckGame;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
// 事件中心管理器
public class EventCenterManager : SingleInstanceBase<EventCenterManager>
{
    private EventCenterManager() { }

    // 
    // 事件中心
    //创建字典，用来存储事件和监听器的关系
    Dictionary<int, UnityAction> eventsDict = new();


    //《事件注册》
    public void AddEventListener(int eventName, UnityAction listener)
    {
        if(!eventsDict.ContainsKey(eventName))
            eventsDict.Add(eventName, listener);
        else
            eventsDict[eventName] += listener;
    
    }

    //发送命令
   
    public void DispatchEvent(int eventName)
    {
        if(eventsDict.ContainsKey(eventName))
        {
            Debug.Log("eventName: "+eventName);
            eventsDict[eventName]?.Invoke();
        }
    }
    //移除监听器

    public void RemoveEventListener(int eventName, UnityAction listener)
    {
        if(eventsDict.ContainsKey(eventName))
        {
            eventsDict[eventName] -= listener;
        }
    }
   //移除所有监听器
    public void RemoveAllEventListener()
    {
        eventsDict.Clear();
    }   

}
