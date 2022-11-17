using Extentions.Factory;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Gameplay.Units.Enemy
{
    public class EnemyProjectileAttack : MonoBehaviour
    {
        [SerializeField] private AssetReference _projectilePrefab;
    }
}