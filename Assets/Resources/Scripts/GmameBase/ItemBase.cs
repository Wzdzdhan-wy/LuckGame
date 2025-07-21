using UnityEngine;

namespace LuckGame 
{
    public class ItemBase : MonoBehaviour, IItem
    {
      
    
        public ItemBase GetItemBase()
        {
            return this;
        }
    
    }

     interface IItem
    {
        void RegisterItem() => EventCenterManager.Instance.TriggerEvent(ItemEvent.RegisterItem,this);
        void UnRegisterItem() => EventCenterManager.Instance.TriggerEvent(ItemEvent.UnRegisterItem,this);
        ItemBase GetItemBase();
    }



}
