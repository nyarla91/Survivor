using RunProgress;
using UnityEngine;
using Zenject;

namespace Shop
{
    public class NextRoundButton : MonoBehaviour
    {
        [SerializeField] private CanvasGroup _canvasGroup;
        
        [Inject] private RunSceneLoader RunSceneLoader { get; set; }

        public void Show()
        {
            _canvasGroup.blocksRaycasts = true;
            _canvasGroup.alpha = 1;
        }

        public void StartNextRound() => RunSceneLoader.JumptoGameplayAsync();
    }
}