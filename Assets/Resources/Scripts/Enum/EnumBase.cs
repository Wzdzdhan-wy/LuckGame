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
  
        StartGame,
        InitGameData,
    }
    public enum UIController {
        ShowUi,
        HideUIForm,
        CloseUIForm,
        UnRegisterForm,
        RegisterForm,
        CloseAllUIForm,
    }

    public enum FormAnimType
    {
        None,
        Fade,
        Zoom,
        Move,
        Rotate,
        Scale,
        Shake,
        Tint,
        Color,
        FadeIn,
        FadeOut,
        MoveIn,
        MoveOut,
        RotateIn,
        RotateOut,
        ScaleIn,
        ScaleOut,
        ShakeIn,
        ShakeOut,
        TintIn,
        TintOut,
        ColorIn,
        ColorOut,

    }
    public enum CardEvent 
    {
        RegisterCard,
        UnRegisterCard,
        PointerEnter,
        PointerExit,
        BeginDrag,
        EndDrag,
        PointerDown,
        PointerUp,
        Select
    }
    public enum ItemEvent
    {
        RegisterItem,
        UnRegisterItem
    }
    public enum AwartEvent 
    {
        RegisterAwart,
        UnRegisterAwart
    }


}
