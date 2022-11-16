using Gameplay.Units;
using Gameplay.Units.Player;
using UnityEngine;
using Zenject;

namespace Gameplay.UI
{
    public class PlayerHUDInstaller : MonoBehaviour
    {
        [SerializeField] private Healthbar _healthbar;
        
        [Inject]
        private void Construct(CharacterComposition character)
        {
            _healthbar.Target = character.HealthPool;
        }
    }
}