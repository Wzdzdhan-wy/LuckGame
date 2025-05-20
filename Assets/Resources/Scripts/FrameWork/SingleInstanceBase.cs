
using System.Runtime;
using System.Collections;
using UnityEngine;
using System;
//单例模式基类
//继承该类可以自动实现单例模式
namespace LuckGame { 
public class SingleInstanceBase<T> where T :SingleInstanceBase<T>
{
    private static T instance;
    protected SingleInstanceBase() { }

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
    
    }

}