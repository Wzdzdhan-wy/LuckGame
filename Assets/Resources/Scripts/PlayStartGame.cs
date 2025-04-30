using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LuckGame;
public class PlayStartGame : MonoBehaviour
{
    public void OnStartButtonClick()
    {
        Debug.Log("buttonOnClick");
        EventCenterManager.Instance().DispatchEvent((int)GameController.OnRoundStart);
       /* EventCenterManager.Instance().DispatchEvent((int)SpinControl.SPIN_START);*/
    }
 
}
