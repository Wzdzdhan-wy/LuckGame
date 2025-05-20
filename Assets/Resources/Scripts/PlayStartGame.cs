using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LuckGame;
using UnityEngine.Events;
public class PlayStartGame : MonoBehaviour
{
    public void OnStartButtonClick()
    {
        Debug.Log("buttonOnClick");
        EventCenterManager.Instance.TriggerEvent(GameController.OnRoundStart);

        Debug.Log(Application.dataPath);

        EventCenterManager.Instance.TriggerEvent(GameController.StartGame);
    }
}
