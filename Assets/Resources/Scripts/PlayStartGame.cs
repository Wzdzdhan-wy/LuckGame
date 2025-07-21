using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LuckGame;
using UnityEngine.Events;
public class PlayStartGame : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            Debug.Log("A");
            EventCenterManager.Instance.TriggerEvent(UIController.ShowUi, "HorizontalGroup");

        }
        if (Input.GetKeyDown(KeyCode.B))
        {
            Debug.Log("B");
            EventCenterManager.Instance.TriggerEvent(UIController.HideUIForm, "HorizontalGroup");

        }
    }
    
    public void OnStartButtonClick()
    {
        Debug.Log("buttonOnClick");
        EventCenterManager.Instance.TriggerEvent(GameController.OnRoundStart);


        EventCenterManager.Instance.TriggerEvent(GameController.StartGame);
    }
}
