﻿using Extentions;
using Gameplay.UI;
using Gameplay.UI.Joystick;
using UnityEngine;

namespace Gameplay.Units.Player
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class CharacterMovement : LazyGetComponent<CharacterComposition>
    {
        [SerializeField] private float _speed;
        
        private Rigidbody2D _rigidbody;
        public Rigidbody2D Rigidbody => _rigidbody ??= GetComponent<Rigidbody2D>();
        public OnScreenJoystick MoveMoystick { get; set; }
        
        private void FixedUpdate()
        {
            Rigidbody.velocity = MoveMoystick.Offset * _speed;
        }
    }
}