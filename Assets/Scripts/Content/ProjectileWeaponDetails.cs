using UnityEngine;

namespace Content
{
    [CreateAssetMenu(menuName = "Content/Projectile Weapon", order = 1)]
    public class ProjectileWeaponDetails : WeaponDetails
    {
        [field: Header("Projectile Stats")]
        [field: SerializeField] public int ProjectilesPerShot { get; private set; }
        [field: SerializeField] public float SpreadAngle { get; private set; }
        [field: SerializeField] public float ProjectileSpeed { get; private set; }
    }
}