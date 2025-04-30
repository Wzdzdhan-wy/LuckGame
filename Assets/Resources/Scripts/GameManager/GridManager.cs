namespace LuckGame
{
    internal class GridManager : SingleInstanceAutoBase<GameManager>
    {
        Card[,] cards = new Card[4,5];
       
        private GridManager() { }

        public void RandomLayout()
        {

        }

       public void Settlement()
        {

        }

        public bool AddCard(Card card)
        {

            return false;
        }
        public bool RemoveCard(Card card)
        {
            return false;
        }
        
    }
}