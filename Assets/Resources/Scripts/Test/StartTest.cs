
using LuckGame;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartTest : MonoBehaviour
{

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            Debug.Log("A");
            EventCenterManager.Instance().TriggerEvent(GameController.ShowUi, "Item");
            UiManager.Instance().ShowUiForm("Item");
        }
        if(Input.GetKeyDown(KeyCode.B))
        {
            Debug.Log("B");
            EventCenterManager.Instance().TriggerEvent(GameController.HideUIForm, "Item");
            
        }
    }

}
