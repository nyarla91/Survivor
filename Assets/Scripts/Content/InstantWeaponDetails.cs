using UnityEngine;

namespace Content
{
    [CreateAssetMenu(menuName = "Content/Instant Weapon", order = 1)]
    public class InstantWeaponDetails : WeaponDetails
    {
        [field: Header("Instant Stats")]
        [field: SerializeField] public float AttackSplash { get; private set; }
        [field: SerializeField] [field: Range(0, 1)] public float SplashDamageModifier { get; private set; }
    }
}