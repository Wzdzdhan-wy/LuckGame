using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
namespace LuckGame { 
    public class GameManager : SingleInstanceAutoBase<GameManager>
    {   
        private GameManager() { }

        public void Awake()
        {
            Instance();
            Debug.Log("GameManager 开始注册事件");
            //注册事件
            EventCenterManager.Instance().AddEventListener((int)GameController.OnRoundStart, RoundStart);
            EventCenterManager.Instance().AddEventListener((int)GameController.OnCoinChanged, CoinChanged);
            MyEventBus.OnItemAdded += ItemAdd;
        }
       
        public void Start()
        {
            
        }

     
        
       
        //事件处理函数 :硬币结算
        private void CoinChanged()
        {
            throw new NotImplementedException();
        }
        //事件处理函数：开始新轮
        private void RoundStart()
        {
            Debug.Log("Round Start");
            EventCenterManager.Instance().DispatchEvent((int)SpinControl.SPIN_START);
        }
        //事件处理函数：道具添加
        private void ItemAdd(Item item)
        {
            Debug.Log("Item Add");
           

        }



        public void OnDisable()
        {
            //注销事件
            EventCenterManager.Instance().RemoveAllEventListener();
        }
    }
}