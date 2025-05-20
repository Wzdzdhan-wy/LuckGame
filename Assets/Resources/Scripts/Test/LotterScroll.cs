using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using System.Collections.Generic;

public class LotterScroll : MonoBehaviour
{
   
    public float scrollDuration = 0.1f; // 每个子项滚动所需时间

    [SerializeField]private RectTransform contentRect;
    private float itemStep; // 每个子项移动的步长
    [SerializeField] private List<Transform> list; // 子项列表
    void Start()
    {
       

        // 计算移动步长：子项高度 + 间隔
        itemStep = 100f + 10f;

        StartInfiniteScroll();
    }

    void StartInfiniteScroll()
    {
        // 当前Y轴位置
        float currentY = contentRect.anchoredPosition.y;
        // 目标Y位置（向上移动一个步长）
        float targetY = currentY - itemStep;

        // 使用DOTween移动
        contentRect.DOAnchorPosY(targetY, 0.1f)
            .SetEase(Ease.Linear)
            .OnComplete(() =>
            {
                // 
                Transform firstChild = contentRect.GetChild(list.Count - 1);
                firstChild.SetAsFirstSibling();

                // 重置容器位置以实现无缝循环
                contentRect.anchoredPosition = new Vector2(
                    contentRect.anchoredPosition.x,
                    currentY // 回到初始Y位置
                );

                // 重新开始动画
                StartInfiniteScroll();
            });
    }
}