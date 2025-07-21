using LuckGame;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardData : CardBase
{
    

    private List<Card> cards = new();
 


    public void SetCards(List<Card> cards)
    {
        this.cards = cards;
    }
    
}
