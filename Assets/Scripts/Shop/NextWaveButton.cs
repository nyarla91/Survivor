using RunProgress;
using UnityEngine;
using Zenject;

namespace Shop
{
    public class NextWaveButton : MonoBehaviour
    {
        [SerializeField] private CanvasGroup _canvasGroup;
        
        [Inject] private RunSceneLoader RunSceneLoader { get; set; }

        public void Show()
        {
            _canvasGroup.blocksRaycasts = true;
            _canvasGroup.alpha = 1;
        }

        public void LoadGameplay() => RunSceneLoader.JumptoGameplayAsync();
    }
}