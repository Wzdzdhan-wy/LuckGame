using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartTest : MonoBehaviour
{
    public GameObject lotteryScrollPrefab; // 预制体引用
    public void OnButtonClick()
    {
        LotteryScroll lotteryScroll = lotteryScrollPrefab.GetComponent<LotteryScroll>();
        lotteryScroll.StartSpin(4);
       // lotteryScroll.StopSpin();

    }
}
