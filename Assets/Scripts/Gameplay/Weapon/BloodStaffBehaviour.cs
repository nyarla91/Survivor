using Extentions;
using Gameplay.Units.Character;
using Zenject;

namespace Gameplay.Weapon
{
    public class BloodStaffBehaviour : ResourceBasedAttackSpeedWeaponBehaviour
    {
        [Inject] private CharacterComposition Character { get; set; }
        protected override ResourceFacade Resource => Character.VitalsPool.Health;
        protected override float PercentToAttackPeriodMultiplier(float percent) => 0.5f + 0.5f * percent;
    }
}