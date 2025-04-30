using LuckGame;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace LuckGame
{
    public class SceneController : SingleInstanceAutoBase<SceneController>
    {
        private SceneController() { }


        [Header("Settuings")]
        //当前
        public Image image;
        public float startSpeed = 0.1f;
        public float acceleration = 0.01f;
        public float interval = 0.5f;
        public int spinRounds = 3;
        public List<Color> colors = new List<Color>();

        [Header("Debug")]
        [SerializeField] private int currentIndex = 0;
        [SerializeField] private bool isSpinning = false;
        [SerializeField] private int targetIndex = 0;
        //初始化一些测试数据
        public void Awake()
        {
            colors.Add(Color.red);
            colors.Add(Color.green);
            colors.Add(Color.blue);
            colors.Add(Color.yellow);
            colors.Add(Color.magenta);

            //注册事件
            Debug.Log("ScenceController 注册事件");
            EventCenterManager.Instance().AddEventListener((int)SpinControl.SPIN_START, StartSpin);
            EventCenterManager.Instance().AddEventListener((int)SpinControl.SPIN_STOP, StopSpin);
        }

        public void StartSpin()
        {
            this.isSpinning = true;
            MonoManager.Instance().StartCoroutine(SlideShow());
        }
        //轮播
        IEnumerator SlideShow()
        {

            while (isSpinning)
            {
                if (colors.Count > 0)
                {
                    image.color = colors[currentIndex];
                    currentIndex = (currentIndex + 1) % colors.Count;
                }
                yield return new WaitForSeconds(interval);
            }
        }
        
        public void StopSpin()
        {
            this.isSpinning = false;
            MonoManager.Instance().StopCoroutine(SlideShow());
            
        }

    }
}