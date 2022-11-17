using Gameplay.Units;
using Gameplay.Units.Player;
using UnityEngine;
using Zenject;

namespace Gameplay.UI
{
    public class PlayerHUDInstaller : MonoBehaviour
    {
        [SerializeField] private Transform _camera;
        [SerializeField] private Healthbar _healthbar;
        
        [Inject]
        private void Construct(CharacterComposition character)
        {
            _healthbar.Target = character.HealthPool;
            _camera.parent = character.Transform;
            _camera.localPosition = new Vector3(0, 0, -10);
        }
    }
}