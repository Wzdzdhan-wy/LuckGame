using UnityEngine;
namespace LuckGame {
    // 所有Awart的基类
    public class AwartBase : MonoBehaviour, IAwart
    {
        private int awartId;
        private int awartType;
       
        public AwartBase GetAwartBase()
        {
            return this;
        }
        private void Awake()
        {
            RegisterAwart();
        }
        private void OnDestroy()
        {
            UnRegisterAwart();
        }

        public void RegisterAwart()
        {
            EventCenterManager.Instance.TriggerEvent(AwartEvent.RegisterAwart, this);
        }

        public void UnRegisterAwart()
        {
            EventCenterManager.Instance.TriggerEvent(AwartEvent.UnRegisterAwart, this);
        }
    }



    interface IAwart 
    {
     void RegisterAwart();
     void UnRegisterAwart();
     AwartBase GetAwartBase();
    }

}