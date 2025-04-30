using System.Collections.Generic;

namespace LuckGame
{
    internal class GlobalEffectManager
    {
        private readonly List<string>  allEffects = new();


        public void ApplyEffect(string effectName)
        {
            allEffects.Add(effectName);
        }

        public void RemoveEffect(string effectName)
        {
            allEffects.Remove(effectName);
        }
        public List<string> GetAllEffects()
        {
            return allEffects;
        }
    }
}