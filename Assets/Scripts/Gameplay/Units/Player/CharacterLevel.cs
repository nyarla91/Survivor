using UnityEngine;

namespace Gameplay.Units.Player
{
    public class CharacterLevel : MonoBehaviour
    {
        [SerializeField] private Resource _experience;

        public ResourceFacade Experience => _experience.Facade;
    }
}