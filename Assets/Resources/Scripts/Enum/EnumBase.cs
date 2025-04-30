using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuckGame
{
    enum CardRare
    {
        COMMON = 0,
        RARE = 1,
        EPIC = 2,
        LEGENDARY = 3,
        MYTHIC = 4
    }
    enum CardType
    {   
        INHERIT = 0,
        PROP = 1
        
    }
    enum EffectType
    {
        None = 0,
    }
    enum ItemType
    {
        none = 0,
        weapon = 1,
        armor = 2,
    }
    enum GameController
    {
        OnItemAdded = 1,
        OnRoundStart = 2,
        OnCoinChanged = 3,
    }
    enum SpinControl
    {
        SPIN_START = 4,
        SPIN_STOP = 5,
    } 
}
