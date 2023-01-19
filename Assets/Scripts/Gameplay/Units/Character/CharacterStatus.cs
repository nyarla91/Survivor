using System;
using Extentions;
using RunProgress;
using Zenject;

namespace Gameplay.Units.Character
{
    public class CharacterStatus : LazyGetComponent<CharacterComposition>
    {
        public event Action OnDeath;
        
        [Inject]
        private void Construct(PlayerStats stats)
        {
            int health = stats.GetStat("health").Value;
            int shields = stats.GetStat("shields").Value;
            int shieldsRegeneration = stats.GetStat("shields regen").Value;
            Lazy.VitalsPool.Init(health, shields, shieldsRegeneration);
            Lazy.VitalsPool.Health.OnOver += Die;
        }

        private void Die()
        {
            Destroy(gameObject);
            OnDeath?.Invoke();
        }
    }
}