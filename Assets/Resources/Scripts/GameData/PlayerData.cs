using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LuckGame {
    /// <summary>
    /// 玩家数据类
    /// </summary>
    public class PlayerData : SingleInstanceBase<PlayerData>
    {
        private string playerName;
        private int coins;
        private int HP;
        private int maxHP;
        private int energy;
        private int handLimit;
        private int maxEnergy;
        private List<Item> playerItems;
        private List<Card> playerCards;
        private void PlayData() { }

        

    }
}