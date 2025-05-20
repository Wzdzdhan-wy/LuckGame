using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class UIAnimation : MonoBehaviour
{
    //UI界面淡入动画
    public static void FadeIn(GameObject obj, float duration = 0.5f)
    {
        obj.SetActive(true);
        obj.GetOrAddComponent<CanvasGroup>().DOFade(1, duration).OnComplete(() =>
        { }
       );
    }
    //UI界面淡出动画
    public static void FadeOut(GameObject obj, float duration = 0.5f)
    {
        obj.GetComponent<CanvasGroup>().DOFade(0, duration).OnComplete(() =>
        obj.SetActive(false)
        
        );

    }
    public static void ZoomIn(GameObject obj, float duration = 0.5f)
    {
        obj.SetActive(true);
        obj.transform.DOScale(1.0f, duration);
    }
    public static void ZoomOut(GameObject obj, float duration = 0.5f)
    {
        obj.transform.DOScale(0.0f, duration).OnComplete(() => 
        obj.SetActive(false));
    }
    
}
