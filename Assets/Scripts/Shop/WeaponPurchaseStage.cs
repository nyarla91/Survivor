using Content;
using RunProgress;
using UnityEngine;
using Zenject;

namespace Shop
{
    public class WeaponPurchaseStage : ShopStage<WeaponDetails>
    {
        [Inject] private ShopPool Pool { get; set; }
        [Inject] private PlayerKit Kit { get; set; }
        protected override WeaponDetails[] ObjPool => Pool.Weapons;
        protected override void ProcessChosenObj(WeaponDetails obj)
        {
            Kit.AddWeapon(obj);
            Pool.RemoveWeapon(obj);
        }
    }
}