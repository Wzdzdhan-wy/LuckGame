using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace LuckGame { 
    public interface ICardEffect 
    {
        void ApplyEffect(BattleManager battleManager, Card card);
    }
}
