using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Content
{
    public class WeaponDetails : ScriptableObject
    {
        [field: SerializeField] public AssetReferenceGameObject Behaviour { get; private set; }
        [field: Header("Display data")]
        [field: SerializeField] public Sprite Sprite { get; private set; }
        [field: SerializeField] public string Name { get; private set; }
        [field: SerializeField] [field: TextArea(5, 15)] public string AbilityDescription { get; private set; }
        [field: Header("Combat stats")]
        [field: SerializeField] public float AttackRange { get; private set; }
        [field: SerializeField] public float AttackPeriod { get; private set; }
        [field: SerializeField] public float DamagePerAttack { get; private set; }
        [field: SerializeField] public DamageType DamageType { get; private set; }
    }
}
