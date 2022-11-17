using Gameplay.UI;
using Gameplay.UI.Joystick;
using UnityEngine;
using Zenject;

namespace Gameplay.Units.Player
{
    public class CharacterDependencyInstaller : MonoBehaviour
    {
        [SerializeField] private Transform _camera;
        [SerializeField] private ResourceBar _healthBar;
        [SerializeField] private ResourceBar _shieldBar;
        [SerializeField] private OnScreenJoystick _moveJoystick;

        [Inject]
        private void Construct(CharacterComposition character)
        {
            _healthBar.Init(character.VitalsPool.Health);
            _shieldBar.Init(character.VitalsPool.Shields);
            _camera.parent = character.Transform;
            
            _camera.localPosition = new Vector3(0, 0, -10);
            
            character.Movement.MoveMoystick = _moveJoystick;
        }
    }
}