using Extentions;
using RunProgress;
using Zenject;

namespace Gameplay.Weapon
{
    public class CrossbowWeaponBehaviour : ResourceBasedAttackSpeedWeaponBehaviour
    {
        [Inject] private PlayerLevel Level { get; }
        protected override ResourceFacade Resource => Level.Experience;
        protected override float PercentToAttackPeriodMultiplier(float percent) => 1 / (1 + percent);
    }
}