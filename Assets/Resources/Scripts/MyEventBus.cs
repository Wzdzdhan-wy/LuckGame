using System;
using UnityEngine.Events;

namespace LuckGame
{
    internal static class MyEventBus
    {
        public static event UnityAction<Item> OnItemAdded;
      
        public static void CallItemAdded(Item item)
        {
            OnItemAdded?.Invoke(item);
        }
 
    }
}