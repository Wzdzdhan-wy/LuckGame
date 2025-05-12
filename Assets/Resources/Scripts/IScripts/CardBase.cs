
using System;
namespace LuckGame { 
    public class CardBase 
    {
        private int  cardId; // 卡牌ID
        private int cardType; // 卡牌类型
        private string cardName; // 卡牌名称
        private string cardDesc; // 卡牌描述
        private int cardRare; // 卡牌稀有度

      public CardBase(int cardId, int cardType, string cardName, string cardDesc, int cardRare)
      {
          this.cardId = cardId;
          this.cardType = cardType;
          this.cardName = cardName;
          this.cardDesc = cardDesc;
          this.cardRare = cardRare;
      }
    public override string ToString()
        {
            return $"CardBase [cardId={cardId}, cardType={cardType}, cardName={cardName}, cardDesc={cardDesc}, cardRare={cardRare}]";
        }

    public override bool Equals(object obj)
    {
        return obj is CardBase @base &&
               cardId == @base.cardId &&
               cardType == @base.cardType &&
               cardName == @base.cardName &&
               cardDesc == @base.cardDesc &&
               cardRare == @base.cardRare;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(cardId, cardType, cardName, cardDesc, cardRare);
    }
}
}