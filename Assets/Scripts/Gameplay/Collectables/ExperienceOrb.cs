using Gameplay.Units.Player;
using RunProgress;
using Zenject;

namespace Gameplay.Collectables
{
    public class ExperienceOrb : Collectable
    {
        [Inject] private PlayerLevel PlayerLevel { get; set; }
        protected override void OnCollect(CharacterComposition character)
        {
            PlayerLevel.AddOneExperience();
        }
    }
}