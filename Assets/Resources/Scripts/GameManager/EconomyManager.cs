namespace LuckGame
{
    internal class EconomyManager :SingleInstanceAutoBase<EconomyManager>
    {
        private EconomyManager() { }
        private int coins;
     
        //金币管理器初始化
        public void Init()
        {

            this.coins = 0;


        }
       
        public void  SetCoins(int coins)
        {
            this.coins = coins;
        }
        public int GetCoins() { return coins; }
        // 金币结算方法
        public int AddCoins(int coins)
        {
            int allCoins = 0;

            return allCoins;
        }
        //金币结算
        public bool PayRent(int rent)
        {
            this.coins -= rent;
            if (coins < 0) { return false; }
            return true;
        }

    }
}