using Extentions;
using Extentions.Factory;
using Gameplay.Weapon;
using RunProgress;
using UnityEngine;
using UnityEngine.AddressableAssets;
using Zenject;

namespace Gameplay.Units.Player
{
    public class CharacterWeapons : Transformable
    {
        [SerializeField] private float _weaponsOffset;
        
        [Inject]
        private void Construct(ContainerFactory factory, PlayerKit kit)
        {
            for (var i = 0; i < kit.Weapons.Count; i++)
            {
                LoadAndInstantiate(kit.Weapons[i], 360 * ((float) i / kit.Weapons.Count));
            }

            async void LoadAndInstantiate(PlayerWeapon weapon, float angle)
            {
                AssetReferenceGameObject reference = weapon.Weapon.Behaviour;
                GameObject prefab = await reference.LoadAssetAsync().Task;
                Vector3 position = Transform.position + (Vector3) angle.DegreesToVector2() * _weaponsOffset;
                WeaponBehaviour behaviour = factory.Instantiate<WeaponBehaviour>(prefab, position, Transform);
            }
        }
    }
}