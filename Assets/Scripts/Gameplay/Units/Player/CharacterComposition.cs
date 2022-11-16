using Extentions;
using UnityEngine;

namespace Gameplay.Units.Player
{
    [RequireComponent(typeof(HealthPool))]
    [RequireComponent(typeof(CharacterMovement))]
    public class CharacterComposition : Transformable
    {
        private HealthPool _healthPool;
        private CharacterMovement _characterMovement;

        public HealthPool HealthPool => _healthPool ??= GetComponent<HealthPool>();
        public CharacterMovement Movement => _characterMovement ??= GetComponent<CharacterMovement>();
    }
}