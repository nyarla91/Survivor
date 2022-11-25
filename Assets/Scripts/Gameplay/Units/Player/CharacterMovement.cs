using Extentions;
using Extentions.Menu;
using Gameplay.UI;
using Gameplay.UI.Joystick;
using UnityEngine;
using Zenject;

namespace Gameplay.Units.Player
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class CharacterMovement : LazyGetComponent<CharacterComposition>
    {
        [SerializeField] private float _speed;
        
        private Rigidbody2D _rigidbody;
        public Rigidbody2D Rigidbody => _rigidbody ??= GetComponent<Rigidbody2D>();
        public OnScreenJoystick MoveMoystick { get; set; }
        
        [Inject] private Pause Pause { get; set; }
        
        private void FixedUpdate()
        {
            if (Pause.IsPaused)
            {
                Rigidbody.velocity = Vector2.zero;
                return;
            }
            Rigidbody.velocity = MoveMoystick.Offset * _speed;
        }
    }
}