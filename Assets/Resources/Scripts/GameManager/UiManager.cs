using System.Collections.Generic;
using UnityEngine;
namespace LuckGame
{
    //管理UI
    /// <summary>
    /// 用于界面管理，继承单例模式，提供以下功能：
    /// 1. 注册UI
    /// 2. 显示UI
    /// 3. 关闭UI
    /// 4. 隐藏UI
    /// 5. 关闭所有UI
    /// </summary>
    public class UiManager :SingleInstanceAutoBase<UiManager>
    {
        //单例模式
        private void UiManage() { }

      
        //创建UI的字典用于存储UI
        Dictionary<string, UIFromBase> forms = new();

        //已启动的UI列表
        private List<UIFromBase> showFroms = new();
        //UI根节点
        public Transform uiRoot
        {
            get { return GameObject.Find("UIRoot").transform; }
        }


        //初始化
        private void Awake()
        {
           
            
            EventCenterManager.Instance.AddEventListener<string>(UIController.ShowUi, ShowUIForm);
            EventCenterManager.Instance.AddEventListener<string>(UIController.HideUIForm, HideUIForm);
            EventCenterManager.Instance.AddEventListener<string>(UIController.CloseUIForm, CloseUIForm);
            EventCenterManager.Instance.AddEventListener(UIController.CloseAllUIForm, CloseAllUIForm);
            EventCenterManager.Instance.AddEventListener<IUIForm>(UIController.RegisterForm, RegisterForm);
            EventCenterManager.Instance.AddEventListener<IUIForm>(UIController.UnRegisterForm, UnRegisterForm);
           
        }

        private void OnDisable()
        {
            EventCenterManager.Instance.RemoveEventListener<string>(UIController.ShowUi, ShowUIForm);
            EventCenterManager.Instance.RemoveEventListener<string>(UIController.HideUIForm, HideUIForm);
            EventCenterManager.Instance.RemoveEventListener<string>(UIController.CloseUIForm, CloseUIForm);
            EventCenterManager.Instance.RemoveEventListener(UIController.CloseAllUIForm, CloseAllUIForm);
            EventCenterManager.Instance.RemoveEventListener<IUIForm>(UIController.RegisterForm, RegisterForm);
            EventCenterManager.Instance.RemoveEventListener<IUIForm>(UIController.UnRegisterForm, UnRegisterForm);
            Clear();
        }

        //添加UI
        private void RegisterForm(IUIForm ui)
        {
           
            if (ui == null) return;
        
            var form = ui.GetUIFromBase();

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
        private void UnRegisterForm(IUIForm ui)
        {
            if (ui == null) return;

            var form = ui.GetUIFromBase();
            if (forms.ContainsKey(form.name)){
                forms.Remove(form.name);
            }
           
        }
        //显示UI
        private void ShowUIForm(string uiName)
        {
            
            if (!forms.ContainsKey(uiName))return;
            Debug.Log("显示UI"+uiName);
            var ui = forms[uiName];
            Debug.Log("显示UI" + ui.name);
            Debug.Log(ui.name);
            if (ui != null)
            {
                ui.Open(this);
                showFroms.Add(ui);
               
            }
        }
        private void ShowUIForm<T>()
        {
           ShowUIForm(typeof(T).Name);
        }
        //关闭UI
        private void CloseUIForm(string uiName)
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
        private void CloseUIForm<T>()
        {
            CloseUIForm(typeof(T).Name);
        }
        //隐藏UI
        private void HideUIForm(string uiName)
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
        //关闭所有UI
        private void CloseAllUIForm()
        {
            foreach (var ui in showFroms)
            {
                ui.Close();
            }
            Clear();
        }
        //清空UI列表
        private void Clear()
        {
            forms.Clear();
            showFroms.Clear();
        }
    }

    public interface IUIForm 
    {
        void RegisterForm() => EventCenterManager.Instance.TriggerEvent(UIController.RegisterForm, this);
        void UnRegisterForm() => EventCenterManager.Instance.TriggerEvent(UIController.UnRegisterForm, this);
        UIFromBase GetUIFromBase();
    }
}