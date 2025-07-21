using LuckGame;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 用来管理游戏中的所有卡牌、物品和奖励
/// 1. 管理卡牌的注册、注销
/// 2. 管理物品的注册、注销
/// 3. 管理奖励的注册、注销
/// </summary>
public class LoadManager : MonoBehaviour
{
    // 卡牌、物品、奖励的字典
    Dictionary<string, CardBase> cardDict = new();
    Dictionary<string, ItemBase> itemDict = new();
    Dictionary<string, AwartBase> awartDict = new();

    // 创建卡牌、物品、奖励的委托
    private void Awake()
    {
        EventCenterManager.Instance.AddEventListener<ICard>(CardEvent.UnRegisterCard, UnRegisterCard);
        EventCenterManager.Instance.AddEventListener<IAwart>(AwartEvent.UnRegisterAwart, UnRegisterAwart);
        EventCenterManager.Instance.AddEventListener<IItem>(ItemEvent.UnRegisterItem, UnRegisterItem);
        EventCenterManager.Instance.AddEventListener<ICard>(CardEvent.RegisterCard, RegisterCard);
        EventCenterManager.Instance.AddEventListener<IAwart>(AwartEvent.RegisterAwart, RegisterAwart);
        EventCenterManager.Instance.AddEventListener<IItem>(ItemEvent.RegisterItem, RegisterItem);
    }

    private void OnDisable()
    {
        EventCenterManager.Instance.RemoveEventListener<ICard>(CardEvent.UnRegisterCard, UnRegisterCard);
        EventCenterManager.Instance.RemoveEventListener<IAwart>(AwartEvent.UnRegisterAwart, UnRegisterAwart);
        EventCenterManager.Instance.RemoveEventListener<IItem>(ItemEvent.UnRegisterItem, UnRegisterItem);
        EventCenterManager.Instance.RemoveEventListener<ICard>(CardEvent.RegisterCard, RegisterCard);
        EventCenterManager.Instance.RemoveEventListener<IAwart>(AwartEvent.RegisterAwart, RegisterAwart);
        EventCenterManager.Instance.RemoveEventListener<IItem>(ItemEvent.RegisterItem, RegisterItem);
    }

    private void RegisterAwart(IAwart awart)
    {
        AwartBase awartBase = awart.GetAwartBase();
        if (awartBase == null) return;
        if (!awartDict.ContainsKey(awartBase.name))
        {
            
            awartDict.Add(awartBase.name, awartBase);
        }
    }

    private void UnRegisterAwart(IAwart awart)
    {
        AwartBase awartBase = awart.GetAwartBase();
        if (awartBase == null) return;
        if (awartDict.ContainsKey(awartBase.name))
        {
            
            awartDict.Remove(awartBase.name);
        }
    }

    private void RegisterItem(IItem item)
    {
        ItemBase itemBase = item.GetItemBase();
        if (itemBase == null) return;
        if (!itemDict.ContainsKey(itemBase.name))
        {
           
            itemDict.Add(itemBase.name, itemBase);
        }
    }

    private void UnRegisterItem(IItem item)
    {
        ItemBase itemBase = item.GetItemBase();
        if (itemBase == null) return;
        if (itemDict.ContainsKey(itemBase.name))
        {
            
            itemDict.Remove(itemBase.name);
        }
    }


    private void RegisterCard(ICard card)
    {
        CardBase cardBase = card.GetCardBase();
        if (cardBase == null) return;
       
        if (!cardDict.ContainsKey(cardBase.name))
        {
           
            cardDict.Add(cardBase.name, cardBase);
        }

    }
    private void UnRegisterCard(ICard card)
    {
        CardBase cardBase = card.GetCardBase();
        if (cardBase == null) return;
        if (cardDict.ContainsKey(cardBase.name))
        {
            cardDict.Remove(cardBase.name);
        }
    }
    
    }
