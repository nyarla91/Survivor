using Gameplay.UI;
using Gameplay.UI.Joystick;
using RunProgress;
using UnityEngine;
using Zenject;

namespace Gameplay.Units.Player
{
    public class PlayerBootstrap : MonoBehaviour
    {
        [SerializeField] private ResourceBar _healthBar;
        [SerializeField] private ResourceBar _shieldBar;
        [SerializeField] private ResourceBar _experienceBar;
        [SerializeField] private OnScreenJoystick _moveJoystick;

        [Inject]
        private void Construct(CharacterComposition character, PlayerLevel level)
        {
            _experienceBar.Init(level.Experience);
            _healthBar.Init(character.VitalsPool.Health);
            _shieldBar.Init(character.VitalsPool.Shields);
            
            character.Movement.MoveMoystick = _moveJoystick;
            
        }
    }
}