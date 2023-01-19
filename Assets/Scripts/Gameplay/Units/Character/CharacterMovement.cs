using Extentions;
using Gameplay.UI.Joystick;
using RunProgress;
using UnityEngine;
using Zenject;

namespace Gameplay.Units.Character
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class CharacterMovement : LazyGetComponent<CharacterComposition>
    {
        [SerializeField] private float _speed;
        
        private Rigidbody2D _rigidbody;
        public Rigidbody2D Rigidbody => _rigidbody ??= GetComponent<Rigidbody2D>();
        public OnScreenJoystick MoveMoystick { get; set; }
        
        [Inject] private Pause Pause { get; set; }
        [Inject] private PlayerStats Stats { get; set; }

        private void Start()
        {
            _speed *= Stats.GetStat("movement speed").PercentValue;
        }

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