using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuckGame
{
    public enum CardRare
    {
        COMMON = 0,
        RARE = 1,
        EPIC = 2,
        LEGENDARY = 3,
        MYTHIC = 4
    }
    public enum CardType
    {   
        INHERIT = 0,
        PROP = 1
        
    }
    public enum EffectType
    {
        None = 0,
    }
    public enum ItemType
    {
        none = 0,
        weapon = 1,
        armor = 2,
    }
    public enum GameController
    {
        OnItemAdded,
        OnRoundStart,
        OnCoinChanged,
        SPIN_START,
        SPIN_STOP,
    }
 
}
