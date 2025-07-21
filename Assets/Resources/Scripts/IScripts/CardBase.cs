using System;
using System.Collections.Generic;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;


namespace LuckGame
{

    public class CardBase : MonoBehaviour, ICard
    {

        private CardInfo cardInfo;  // 卡牌信息

        private void Awake()
        {
         
            EventCenterManager.Instance.AddEventListener<ICard> (CardEvent.RegisterCard, RegisterCard);
            EventCenterManager.Instance.AddEventListener<ICard> (CardEvent.UnRegisterCard, UnRegisterCard);
            
        }
        private void OnDestroy()
        {
           UnRegisterCard(this);
        }


        public void RegisterCard(ICard card)
        {
            if (cardInfo.Equals(default(CardInfo))) return;
            
            

        }

        public void UnRegisterCard(ICard card)
        {
          
        }



        public void CardBuff( )
        {
            
        }

        public CardBase GetCardBase()
        {
            return this;
        }
    }
}