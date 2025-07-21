
using System.Runtime;
using System.Collections;
using UnityEngine;
using System;
//
/**
 * 单例模式基类
 * 继承该类可以自动实现单例模式 
 * 不继承MonoBehavior类，可以实现在非MonoBehavior类中实现单例模式
 * 用于各种工具类，游戏状态管理类，全局数据管理类等
 */
namespace LuckGame { 
public class SingleInstanceBase<T> where T :SingleInstanceBase<T>
{
    private static T instance;
    protected SingleInstanceBase() { }

    //单例模式 获取实例
    public static T Instance
    {
        get
        {
                if (instance == null)
                {
                    instance = Activator.CreateInstance(typeof(T), true) as T;
                }
                return instance;
        }
    }

    public static void DestroyInstance()
        {
            if (instance!= null)
            {
                instance = null;
            }
        }
    
    }

}