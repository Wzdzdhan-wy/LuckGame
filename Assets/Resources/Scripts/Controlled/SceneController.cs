using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class SceneController : MonoBehaviour
{
    [Header("References")]
    public RectTransform content; // 需要滚动的父物体
    public float scrollSpeed = 50f; // 像素/秒

    [Header("Settings")]
    private float itemHeight = 110f; // 100高度 + 10间距
    private float maskHeight = 450f;
    private Vector2 startPos;

    void Start()
    {
        // 禁用VerticalLayoutGroup的自动布局
        Destroy(GetComponent<VerticalLayoutGroup>());

        // 初始化参数
        maskHeight = GetComponent<RectTransform>().rect.height;
        itemHeight = 100f + 10f; // 元素高度 + 间距

        // 手动排列子物体位置
        ArrangeChildren();

        // 开始滚动
        StartInfiniteScroll();
    }

    void ArrangeChildren()
    {
        float currentY = -10f; // 初始Top偏移
        foreach (RectTransform child in content)
        {
            child.anchoredPosition = new Vector2(0, currentY);
            currentY -= itemHeight; // 向下排列
        }
    }

    void StartInfiniteScroll()
    {
        // 计算完整滚动一个元素需要的时间
        float duration = itemHeight / scrollSpeed;

        content.DOAnchorPosY(content.anchoredPosition.y + itemHeight, duration)
            .SetEase(Ease.Linear)
            .OnComplete(() =>
            {
                // 将第一个元素移到最后
                Transform firstChild = content.GetChild(0);
                firstChild.SetAsLastSibling();

                // 重置所有元素位置
                ResetPositions();

                // 继续下一次滚动
                StartInfiniteScroll();
            });
    }

    void ResetPositions()
    {
        // 调整所有子物体位置
        float currentY = -10f;
        foreach (RectTransform child in content)
        {
            child.anchoredPosition = new Vector2(0, currentY);
            currentY -= itemHeight;
        }

        // 重置content位置
        content.anchoredPosition = Vector2.zero;
    }
}