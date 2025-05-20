using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuckGame
{
    public enum CardRare
    {
        COMMON ,
        RARE,
        EPIC,
        LEGENDARY,
        MYTHIC
    }
    public enum CardType
    {   
        INHERIT,
        PROP 
        
    }
    public enum EffectType
    {
        None,
    }
    public enum ItemType
    {
        none ,
        weapon,
        armor,
    }
    public enum GameController
    {
        OnItemAdded,
        OnRoundStart,
        OnCoinChanged,
        OnItemAdd,
        SPIN_START,
        SPIN_STOP,
        ShowUi,
        HideUIForm,
        CloseUIForm,
        UnRegisterForm,
        RegisterForm,
        CloseAllUIForm,
        StartGame,
        InitGameData,
    }
    public enum FormAnimType
    {
        None,
        Fade,
        Zoom

    }
 
}
