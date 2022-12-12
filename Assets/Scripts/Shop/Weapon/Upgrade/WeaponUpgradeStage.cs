using RunProgress;
using Zenject;

namespace Shop.Weapon.Upgrade
{
    public class WeaponUpgradeStage : ShopStage<PlayerWeapon>
    {
        [Inject] private PlayerKit Kit { get; set; }
        protected override PlayerWeapon[] ObjPool => Kit.Weapons.ToArray();
        protected override void ProcessChosenObj(PlayerWeapon obj)
        {
            obj.Upgrade();
        }
    }
}