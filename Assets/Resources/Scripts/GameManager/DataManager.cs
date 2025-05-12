using LuckGame;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : SingleInstanceAutoBase<DataManager>
{
   
    private List<Item> playerItems;
    private List<Item> allItems;
    private List<Item> storeItems;
    private List<Item> boxItems;
    private List<Card> storeCards;
    private List<Card> playerCards;
    private List<Card> boxCards;
    private List<Card> allCards;
  
    public void Init()
    {
        allItems = new List<Item>();
        storeItems = new List<Item>();
        boxItems = new List<Item>();
        storeCards = new List<Card>();
        boxCards = new List<Card>();
        allCards = new List<Card>();
    }

    public void AddPlayerItem(Item item)
    {
        playerItems.Add(item);
    }

    public void AddAllItem(Item item)
    {
        allItems.Add(item);
    }

    public void AddStoreItem(Item item)
    {
        storeItems.Add(item);
    }

    public void AddBoxItem(Item item)
    {
        boxItems.Add(item);
    }

    public void AddPlayerCard(Card card)
    {
        playerCards.Add(card);
    }

    public void AddAllCard(Card card)
    {
        allCards.Add(card);
    }

    public void AddStoreCard(Card card)
    {
        storeCards.Add(card);
    }

    public void AddBoxCard(Card card)
    {
        boxCards.Add(card);
    }
    public void RemovePlayerItem(Item item)
    {
        playerItems.Remove(item);
    }
    public void RemoveAllItem(Item item)
    {
        allItems.Remove(item);
    }
    public void RemoveStoreItem(Item item)
    {
        storeItems.Remove(item);
    }
    public void RemoveBoxItem(Item item)
    {
        boxItems.Remove(item);
    }
    public void RemovePlayerCard(Card card)
    {
        playerCards.Remove(card);
    }
    public void RemoveAllCard(Card card)
    {
        allCards.Remove(card);
    }
    public void RemoveStoreCard(Card card)
    {
        storeCards.Remove(card);
    }
    public void RemoveBoxCard(Card card)
    {
        boxCards.Remove(card);
    }

}
