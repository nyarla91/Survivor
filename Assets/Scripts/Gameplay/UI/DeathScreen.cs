using Gameplay.Units.Player;
using Zenject;

namespace Gameplay.UI
{
    public class DeathScreen : Menu.Menu
    {
        [Inject]
        private void Construct(CharacterStatus character)
        {
            character.OnDeath += Open;
        }
    }
}