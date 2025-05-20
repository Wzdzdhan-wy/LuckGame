using DG.Tweening;
using LuckGame;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class SceneController : MonoBehaviour
{

    private float scrollDuration;// 每个子项滚动所需时间
   
    [SerializeField] private RectTransform contentRect;
    private float itemStep; // 每个子项移动的步长
    [SerializeField] private List<Transform> list; // 子项列表
                                                   
    private Coroutine _scrollCoroutine;
    public float decreaseSpeed = 0.2f;
    private bool isStart = false; // 是否开始
    private void Awake()
    {
       EventCenterManager.Instance.AddEventListener(GameController.StartGame, StartGame);
    }
    void Start()
    {

        // 计算移动步长：子项高度 + 间隔
        itemStep = 100f;
       
       
    }
 
      
    
    
    public void StartGame()
    {
        if (!isStart) {
        isStart = true;
        scrollDuration  = 0.1f;
            if (_scrollCoroutine != null)
                MonoManager.Instance.StopCouroutine(_scrollCoroutine);

            _scrollCoroutine = MonoManager.Instance.StartCoroutine(StartInfiniteScroll());
            MonoManager.Instance.StartCoroutine(StopInfiniteScroll());
        }
    }
    IEnumerator StopInfiniteScroll()
    {
        yield return new WaitForSeconds(1f);
        float duration = 1f; // 渐变持续时间
        float startValue = scrollDuration;
        float elapsed = 0;

        while (elapsed < duration)
        {
            scrollDuration = Mathf.Lerp(startValue, 1f, elapsed / duration);
            elapsed += Time.deltaTime;
            yield return null;
        }
     
        isStart = false;
    }

    IEnumerator StartInfiniteScroll()
    {
        while (isStart) // 改用循环代替递归
        {
            float currentY = contentRect.anchoredPosition.y;
            float targetY = currentY - itemStep;

            // 使用异步等待代替回调
            yield return contentRect.DOAnchorPosY(targetY, scrollDuration)
                .SetEase(Ease.Linear)
                .WaitForCompletion();

            // 完成移动后操作
            Transform firstChild = contentRect.GetChild(contentRect.childCount - 1);
            TextMeshProUGUI text = firstChild.GetChild(0).GetComponent<TextMeshProUGUI>();
            text.text = Random.Range(1, 100).ToString();
            firstChild.SetAsFirstSibling();
            contentRect.anchoredPosition = new Vector2(contentRect.anchoredPosition.x, currentY);
        }
    }


}