using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
namespace LuckGame {

    //MonoManager 单例管理器
    //管理MonoController的生命周期
    //用于协程管理
    public class MonoManager : SingleInstanceBase<MonoManager>
    {
        private MonoManager(){}

        private MonoController monoController;
        private MonoController MonoExecuter
        {
            get {
                if (monoController == null)
                {
                    GameObject go = new GameObject(typeof(MonoController).Name);
                    monoController = go.AddComponent<MonoController>();
                    return monoController;
                }
                return monoController;
            }    
        }
 
        //启动协程       
        public Coroutine StartCoroutine(IEnumerator routine)
        {

           return MonoExecuter.StartCoroutine(routine);

        }



        public Coroutine StartCoroutine(IEnumerable enumerable)
        {
            
            IEnumerator enumerator = enumerable.GetEnumerator();
            return MonoExecuter.StartCoroutine(enumerator);
        }
        //停止协程
        public void StopCoroutine(IEnumerator routine)
        {
            if (routine == null) return;
            MonoExecuter.StopCoroutine(routine);  
        }
        //停止协程
        public void StopCoroutine(Coroutine routine)
        {
            if (routine == null) return;
            MonoExecuter.StopCoroutine(routine);
        }
        //停止所有协程
        public void StopAllCoroutines()
        {
            if (MonoExecuter == null) return;
            MonoExecuter.StopAllCoroutines();
        }
        //添加Update事件
        public void AddUpdateListener(UnityAction listener)
        {
            MonoExecuter.AddUpdateListener(listener);
        }

        //移除Update事件
        public void RemoveUpdateListener(UnityAction listener)
        {
            MonoExecuter.RemoveUpdateListener(listener);
        }
        //移除所有Update事件
        public void RemoveAllUpdateListener()
        {
            MonoExecuter.RemoveAllUpdateListener();
        }

        //添加Fixedupdate事件
        public void AddFixedUpdateListener(UnityAction listener)
        {
            MonoExecuter.AddFixedUpdateListener(listener);
        }
        //移除Fixedupdate事件
        public void RemoveFixedUpdateListener(UnityAction listener)
        {
            MonoExecuter.RemoveFixedUpdateListener(listener);
        }
        //移除所有Fixedupdate事件
        public void RemoveAllFixedUpdateListener()
        {
            MonoExecuter.RemoveAllFixedUpdateListener();
        }

    }

}

    //该脚本用于开启和关闭协程，也可以通过它来监听UPdate，FixedUpdate等事件
    class MonoController :MonoBehaviour
    {

        event UnityAction UpdateEvent;
        event UnityAction FixedUpdateEvent;
         void Update()
        {
            UpdateEvent?.Invoke();
            
        }
        void FixedUpdate()
        {
            FixedUpdateEvent?.Invoke();
        }
        private void OnDestroy()
        {

            UpdateEvent = null;
            FixedUpdateEvent = null;
        }
    public void AddUpdateListener(UnityAction call)
        {
            UpdateEvent += call;

        }
        public void RemoveUpdateListener(UnityAction call)
        {
            if (UpdateEvent == null) return;
            UpdateEvent -= call;
        }
        public void RemoveAllUpdateListener()
        {
            UpdateEvent = null;
        }
        
        public void AddFixedUpdateListener(UnityAction call)
        {
            FixedUpdateEvent += call;
        }
        public void RemoveFixedUpdateListener(UnityAction call)
        {
            if (FixedUpdateEvent == null) return;
            FixedUpdateEvent -= call;
        }
        public void RemoveAllFixedUpdateListener()
        {
            FixedUpdateEvent = null;
        }
    }
