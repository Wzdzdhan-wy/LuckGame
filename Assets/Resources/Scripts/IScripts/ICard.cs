
namespace LuckGame
{
    public interface ICard
    {
        void RegisterCard(ICard card);
        void UnRegisterCard(ICard card); 
        CardBase GetCardBase();
        
    }

}