using System;

using UnityEngine;
namespace LuckGame { 
    public class GameManager : SingleInstanceAutoBase<GameManager>
    {   
        private GameManager() { }

        public void Awake()
        {
            EventCenterManager.Instance(true);
            Debug.Log("GameManager 开始注册事件");
            //注册事件
            EventCenterManager.Instance().AddEventListener(GameController.OnRoundStart, RoundStart);
            EventCenterManager.Instance().AddEventListener(GameController.OnCoinChanged, CoinChanged);
            EventCenterManager.Instance().AddEventListener<Item>(GameController.OnItemAdded, ItemAdd);
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
            EventCenterManager.Instance().TriggerEvent(GameController.SPIN_START);

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