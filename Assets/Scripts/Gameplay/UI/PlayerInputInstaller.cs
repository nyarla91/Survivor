using Gameplay.UI.Joystick;
using Gameplay.Units.Player;
using UnityEngine;
using Zenject;

namespace Gameplay.UI
{
    public class PlayerInputInstaller : MonoBehaviour
    {
        [SerializeField] private OnScreenJoystick _moveJoystick;

        [Inject]
        private void Construct(CharacterMovement movement)
        {
            movement.MoveMoystick = _moveJoystick;
        }
    }
}