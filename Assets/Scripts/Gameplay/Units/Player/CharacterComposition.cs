using Extentions;
using UnityEngine;

namespace Gameplay.Units.Player
{
    [RequireComponent(typeof(VitalsPool))]
    [RequireComponent(typeof(CharacterMovement))]
    public class CharacterComposition : Transformable
    {
        private VitalsPool _vitalsPool;
        private CharacterMovement _characterMovement;
        private CharacterStatus _status;

        public VitalsPool VitalsPool => _vitalsPool ??= GetComponent<VitalsPool>();
        public CharacterMovement Movement => _characterMovement ??= GetComponent<CharacterMovement>();
        public CharacterStatus Status => _status ??= GetComponent<CharacterStatus>();
    }
}