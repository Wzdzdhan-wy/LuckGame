namespace LuckGame
{
    internal class RoundController :SingleInstanceAutoBase<RoundController>
    {
        private RoundController() { }
        private int roundNumber = 0;
        //private bool isGameOver = false;
        //private bool isRoundOver = false;

        public void Init()
        {

        }
        public void SpinPhase()
        {
          
            roundNumber += 1;

        }
        public void ChoincePhase()
        {

        }
    }
}