using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
namespace LuckGame {
    public class UIFromBase : MonoBehaviour, IUIForm
    {

        private UiManager uiManager;
        private bool IsOpen = true;
        private RectTransform rectTransform;
        private Vector3 localPosition;
        private Vector3 targetPosition;
        public FormAnimType formAnimType;
        private void Awake()
        {
            IUIForm uiForm = this;
            uiForm.RegisterForm();
            localPosition = transform.position;
          
            targetPosition.y += 1000;
            Debug.Log("UIFromBase Awake"+ Screen.height);
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
            OpenAnim();
            this.uiManager = uiManager;
            
        }
        public void Close()
        {
            if (!IsOpen)
            {
                return;
            }
            IsOpen = false;
            CloseAnim();
          
        }

        public void OpenAnim()
        {
            switch (formAnimType)
            {
                case FormAnimType.None:
                    gameObject.SetActive(true);
                    break;
                case FormAnimType.Zoom:
                    UIAnimation.ZoomIn(gameObject);
                    break;
                case FormAnimType.Fade:
                    UIAnimation.FadeIn(gameObject);
                    break;
                default:
                case FormAnimType.Move:
                    UIAnimation.MoveIn(gameObject,localPosition);
                    break;
            }
        }
        public void CloseAnim()
        {
            switch (formAnimType)
            {
                case FormAnimType.None:
                    gameObject.SetActive(false);
                    break;
                case FormAnimType.Fade:
                    UIAnimation.FadeOut(gameObject);
                    break;
                case FormAnimType.Zoom:
                    UIAnimation.ZoomOut(gameObject);
                    break;
                case FormAnimType.Move:
                    UIAnimation.MoveOut(gameObject, targetPosition);
                    break;
                default:
                    break;
            }
        }
    }
}
