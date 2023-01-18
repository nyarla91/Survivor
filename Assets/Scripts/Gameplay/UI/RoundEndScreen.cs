using RunProgress;
using UIUtilities;
using Zenject;

namespace Gameplay.UI
{
    public class RoundEndScreen : Window
    {
        [field: Inject] private RunSceneLoader SceneLoader { get; set; }
        [field: Inject] private RunRounds RunRounds { get; set; }

        public void JumpToShop()
        {
            RunRounds.NextRound();
            SceneLoader.JumptoShopAsync();
        }
    }
}