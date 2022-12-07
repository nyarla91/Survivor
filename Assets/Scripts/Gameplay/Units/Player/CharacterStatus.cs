using Extentions;
using RunProgress;
using UnityEngine;
using Zenject;

namespace Gameplay.Units.Player
{
    public class CharacterStatus : LazyGetComponent<CharacterComposition>
    {
        [Inject]
        private void Construct(PlayerStats stats)
        {
            int health = stats.GetStat("health").Value;
            int shields = stats.GetStat("shields").Value;
            int shieldsRegeneration = stats.GetStat("shields regen").Value;
            print($"{health} {shields} {shieldsRegeneration}");
            Lazy.VitalsPool.Init(health, shields, shieldsRegeneration);
        }
    }
}