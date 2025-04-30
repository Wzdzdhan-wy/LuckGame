namespace LuckGame
{
    internal interface IGameState
    {
        void MenuState();
        void PlayingState();
        void PausedStae();
    }
    internal class GameStateMachine : IGameState
    {
        public void MenuState()
        {
            throw new System.NotImplementedException();
        }

        public void PausedStae()
        {
            throw new System.NotImplementedException();
        }

        public void PlayingState()
        {
            throw new System.NotImplementedException();
        }
    }


}