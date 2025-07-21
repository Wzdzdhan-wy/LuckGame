using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class UIAnimation : MonoBehaviour
{
    // 是否跳过动画
    public static bool isSkipAnimating = false;
    //UI界面淡入动画
    public static void FadeIn(GameObject obj, float duration = 0.5f)
    {
        obj.GetOrAddComponent<CanvasGroup>().DOKill();
        obj.SetActive(true);
        obj.GetOrAddComponent<CanvasGroup>().alpha = 0;
        obj.GetOrAddComponent<CanvasGroup>().DOFade(1, duration);
    }
    //UI界面淡出动画
    public static void FadeOut(GameObject obj, float duration = 0.5f)
    {
        obj.GetOrAddComponent<CanvasGroup>().DOKill();
        obj.GetComponent<CanvasGroup>().DOFade(0, duration).OnComplete(() =>
        {
            obj.SetActive(false);
        }
        ); 
        

    }
    public static void ZoomIn(GameObject obj, float duration = 0.5f)
    {
        obj.transform.DOKill();
        obj.SetActive(true);
        obj.transform.localScale = Vector3.zero;
        obj.transform.DOScale(1.0f, duration);
       
    }
    public static void ZoomOut(GameObject obj, float duration = 0.5f)
    {
        obj.transform.DOKill();
        obj.transform.DOScale(0.0f, duration).OnComplete(() =>
        {
          obj.SetActive(false);
        }
       );
       
    }

    public static void MoveIn(GameObject obj, Vector3 location, float duration = 0.5f)
    {
        obj.transform.DOKill();
        obj.SetActive(true);
       
        obj.transform.DOMove(location, duration);
       
    }
    public static void MoveOut(GameObject obj, Vector3 move, float duration = 0.5f)
    {
        obj.transform.DOKill();
        obj.transform.DOMove(move, duration).OnComplete(() =>
        {
            obj.SetActive(false);
        });
       
    }
}
