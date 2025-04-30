using System;
using UnityEngine.Events;

namespace LuckGame
{
    internal static class MyEventBus
    {
        public static event UnityAction<Item> OnItemAdded;
        public static event UnityAction OnRoundStart;
        public static event UnityAction OnCoinChanged;

        public static void CallItemAdded(Item item)
        {
            OnItemAdded?.Invoke(item);
        }
        public static void CallRoundStart()
        {
            OnRoundStart?.Invoke();
        }
        public static void CallCoinChanged()
        {
            OnCoinChanged?.Invoke();
        }
    }
}