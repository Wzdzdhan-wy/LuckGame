using System.Collections.Generic;
using UnityEngine;

namespace LuckGame
{
    // Item数据信息

    public struct ItemInfo
    {

        public int id;
        public string name;
        public string description;
        public int type;
        public int value;
    }
    public class Item :ItemBase
    {
        private  ItemInfo itemInfo;


        public virtual void SetItemInfo(ItemInfo itemInfo)
        {
            this.itemInfo = itemInfo;
        }

        

    }
}