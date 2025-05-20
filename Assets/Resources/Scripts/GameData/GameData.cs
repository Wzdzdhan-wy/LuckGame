using LuckGame;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class GameData :MonoBehaviour
{
    private List<Item> allItems;
    private List<Card> allCards;
    private List<PlayerData> allPlayerData;
    private List<MonsterData> allMonsterData;
    private List<AwartData> allAwartData;
    private void Awake()
    {
        EventCenterManager.Instance.AddEventListener(GameController.InitGameData, InitGameData);
    }
    public void InitGameData()
    {
        allItems = new List<Item>();
        allCards = new List<Card>();
        allPlayerData = new List<PlayerData>();
        allMonsterData = new List<MonsterData>();
        allAwartData = new List<AwartData>();
        LoadData();
    }

    private void LoadData()
    {
     
    }

}
