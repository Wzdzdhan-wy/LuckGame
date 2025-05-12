using System.Collections.Generic;
using UnityEngine;
namespace LuckGame
{
    public class UiManager :SingleInstanceAutoBase<UiManager>
    {
        private void UiManage() { }

      
       
        Dictionary<string, UIFromBase> forms = new();

       
        public List<UIFromBase> showFroms = new();
        public Transform uiRoot
        {
            get { return GameObject.Find("UIRoot").transform; }
        }



        private void Awake()
        {
            EventCenterManager.Instance().AddEventListener<string>( GameController.ShowUi, ShowUiForm);
            EventCenterManager.Instance().AddEventListener<string>(GameController.HideUIForm, HideUIForm);
            EventCenterManager.Instance().AddEventListener<string>(GameController.CloseUIForm, CloseUIForm);
        }



        //添加UI
        public void RegisterForm(IUIForm ui)
        {
           
            if (ui == null) return;
        
            var form = ui.GetUIFromBase();
            Debug.Log("注册UI" + form.name);
            if ((!forms.ContainsKey(form.name)))
            {
                forms.Add(form.name, form);
                form.Close();
            }
            else
            {
                forms[form.name] = form;
            }
          
           
        }
        //移除UI
        public void UnRegisterForm(IUIForm ui)
        {
            if (ui == null) return;
            Debug.Log("注销UI");
            var form = ui.GetUIFromBase();
            if (forms.ContainsKey(form.name)){
                forms.Remove(form.name);
            }
           
        }
       
        public void ShowUiForm(string uiName)
        {
            
            if (!forms.ContainsKey(uiName))return;
            Debug.Log("显示UI");
            var ui = forms[uiName];
            Debug.Log(ui.name);
            if (ui != null)
            {
                ui.Open(this);
                showFroms.Add(ui);
               
            }
        }
        public void CloseUIForm(string uiName)
        {
           
            if (forms.ContainsKey(uiName))
            {
                Debug.Log("关闭UI");
                var ui = forms[uiName];
                if (ui != null)
                {
                    ui.Close();
                    showFroms.Remove(ui);
                }
            }
        }
        public void HideUIForm(string uiName)
        {
           if (!forms.ContainsKey(uiName)) return;
            var ui = forms[uiName];

            if (showFroms.Contains(ui))
            {
                Debug.Log("隐藏UI");
                ui.Close();
                showFroms.Remove(ui);
            }

        }
    }

    public interface IUIForm 
    {
        void RegisterForm() =>UiManager.Instance().RegisterForm(this);
        void UnRegisterForm() => UiManager.Instance().UnRegisterForm(this);
        UIFromBase GetUIFromBase();
    }

}