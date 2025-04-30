using System.Collections.Generic;

namespace LuckGame
{
     class Item
    {
        private int id;
        private string name;
        private int itemType;
        private readonly List<ItemData> itemDatas;

        public Item(int id, string name, int itemType, List<ItemData> itemDatas)
        {
            
            this.id = id;
            this.name = name;
            this.itemType = itemType;
            this.itemDatas = itemDatas;
        }
    }
}