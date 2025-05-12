using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace LuckGame {
    public class UIFromBase :MonoBehaviour, IUIForm
    {

        private UiManager uiManager;
        private bool IsOpen = false;
        private void Awake()
        {
            IUIForm uiForm = this;
            uiForm.RegisterForm();
        }
        private void OnDestroy()
        {
            IUIForm uiForm = this;
            uiForm.UnRegisterForm();
        }
        public UIFromBase GetUIFromBase()
        {
            return this;   
        }
        public void Open(UiManager uiManager)
        {
            if (IsOpen)
            {
                return;
            }
            IsOpen = true;
            this.uiManager = uiManager;
            gameObject.SetActive(true);
        }
        public void Close()
        {
            if (!IsOpen)
            {
                return;
            }
            IsOpen = false;
            gameObject.SetActive(false);
        }
    }
}
