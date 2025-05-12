using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class LotterScroll : MonoBehaviour
{
   
    public float scrollDuration = 2f; // 每个子项滚动所需时间

    [SerializeField]private RectTransform contentRect;
    private float itemStep; // 每个子项移动的步长

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
        contentRect.DOAnchorPosY(targetY, scrollDuration)
            .SetEase(Ease.Linear)
            .OnComplete(() =>
            {
                // 将第一个子对象移到最后
                Transform firstChild = contentRect.GetChild(0);
                firstChild.SetAsLastSibling();

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