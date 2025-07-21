using UnityEngine;

namespace LuckGame
{
    public class VisualCardsHandler: MonoBehaviour
    {
        private static VisualCardsHandler instance;
        private void Awake()
        {
            instance = this;

        }
    }
}