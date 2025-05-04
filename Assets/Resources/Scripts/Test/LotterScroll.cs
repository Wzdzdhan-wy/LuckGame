using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using System.Collections;
using System.Collections.Generic;

public class LotteryScroll : MonoBehaviour
{
    [Header("UI References")]
    public RectTransform content;      // 滚动内容容器
    
    public float itemHeight = 100f;    // 单个奖品项高度

    [Header("滚动设置")]
    public float baseSpeed = 0.05f;     // 基础速度（秒/项）
    public int minSpins = 20;          // 最小滚动圈数
    public float decelerateDuration = 2.5f; // 减速时间
    public Ease stopEase = Ease.OutQuint; // 停止缓动类型

    private int totalItems = 6;            // 原始奖品数量
    private int virtualIndex;          // 虚拟位置索引
    private bool isSpinning = false;
    private int targetIndex = 0;
    private List<RectTransform> itemPool = new();

    void Start()
    {
        DOTween.Init();
        InitializePool();
      
    }

    // 初始化对象池
    void InitializePool()
    {
        // 获取原始项并克隆
        totalItems = content.childCount;
        for (int i = 0; i < totalItems; i++)
        {
            var original = content.GetChild(i).GetComponent<RectTransform>();
            itemPool.Add(original);

            // 创建克隆项
            var clone = Instantiate(original, content);
            clone.name = original.name + "_Clone";
            itemPool.Add(clone);
        }

        // 设置初始位置
        content.anchoredPosition = Vector2.zero;
    }

    public void StartSpin(int resultIndex)
    {
        if (isSpinning) return;

        targetIndex = resultIndex;
        isSpinning = true;
        

        StartCoroutine(SpinRoutine());
    }

    IEnumerator SpinRoutine()
    {
        // 第一阶段：加速
        float currentSpeed = baseSpeed;
        virtualIndex = 0;

        for (int i = 0; i < minSpins * totalItems; i++)
        {
            yield return MoveOneItem(currentSpeed);

            // 动态加速
            currentSpeed = Mathf.Lerp(baseSpeed, 0.01f, (float)i / (minSpins * totalItems));
        }

        // 第二阶段：减速停止
        yield return DecelerateToStop();

        isSpinning = false;
     
    }

    IEnumerator MoveOneItem(float duration)
    {
        content.DOAnchorPosY(content.anchoredPosition.y + itemHeight, duration)
              .SetEase(Ease.Linear);

        yield return new WaitForSeconds(duration);

        virtualIndex++;
        CheckLoopBoundary();
    }

    IEnumerator DecelerateToStop()
    {
        int remainingSteps = (targetIndex - virtualIndex % totalItems + totalItems) % totalItems;
        float targetY = content.anchoredPosition.y + remainingSteps * itemHeight;

        content.DOKill();
        yield return content.DOAnchorPosY(targetY, decelerateDuration)
                           .SetEase(stopEase)
                           .WaitForCompletion();

        SnapToPosition(targetY);
        ResetItemOrder();
    }

    void CheckLoopBoundary()
    {
        if (virtualIndex % totalItems == 0)
        {
            // 重置位置并调整项顺序
            content.anchoredPosition -= Vector2.up * (totalItems * itemHeight);
            ResetItemOrder();
        }
    }

    void ResetItemOrder()
    {
        // 将前N项移到底部
        for (int i = 0; i < totalItems; i++)
        {
            var first = content.GetChild(0);
            first.SetAsLastSibling();
            first.GetComponent<RectTransform>().anchoredPosition +=
                Vector2.down * totalItems * itemHeight;
        }
    }

    void SnapToPosition(float targetY)
    {
        // 精确对齐到最近的整数值
        float snappedY = Mathf.Round(targetY / itemHeight) * itemHeight;
        content.anchoredPosition = new Vector2(0, snappedY);

        Debug.Log($"精确定位到：{snappedY}");
    }

    // 调试用：显示当前可见项
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log($"当前虚拟索引：{virtualIndex} | 实际位置：{content.anchoredPosition.y}");
        }
    }
}