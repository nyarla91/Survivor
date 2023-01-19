using Gameplay.Units.Character;
using UIUtilities;
using Zenject;

namespace Gameplay.UI
{
    public class DeathScreen : Window
    {
        [Inject]
        private void Construct(CharacterStatus character)
        {
            character.OnDeath += Open;
        }
    }
}