using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace RunProgress
{
    public class RunSceneLoader : MonoBehaviour
    {
        [SerializeField] private AssetReference _loadingScene;
        [SerializeField] private AssetReference _shopScene;
        [SerializeField] private AssetReference _gameplayScene;

        public async Task JumptoShopAsync()
        {
            await _loadingScene.LoadSceneAsync().Task;
            await _shopScene.LoadSceneAsync().Task;
        }
        
        public async Task JumptoGameplayAsync()
        {
            await _loadingScene.LoadSceneAsync().Task;
            await _gameplayScene.LoadSceneAsync().Task;
        }
    }
}