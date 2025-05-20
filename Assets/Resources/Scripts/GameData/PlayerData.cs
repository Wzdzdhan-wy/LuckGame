using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LuckGame {
    /// <summary>
    /// 玩家数据类
    /// </summary>
    public class PlayerData 
    {
       
        private string PlayerName { get; set; }
        private int playerCoins;
        private int playerHP;
        private int playerMaxHP;
        private int playerEnergy;
        private int playerMaxHand;
        private int playerMaxEnergy;
        private List<Item> playerItems;
        private List<Card> playerCards;

    }
}