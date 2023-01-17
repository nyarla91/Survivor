using DG.Tweening;
using Extentions;
using UnityEngine;

namespace UIUtilities
{
    public class WindowView : LazyGetComponent<Window>
    {
        private CanvasGroup _canvasGroup;
        private CanvasGroup CanvasGroup => _canvasGroup ??= GetComponent<CanvasGroup>();
        
        private void Awake()
        {
            Lazy.OnOpen += FadeIn;
            Lazy.OnClose += FadeOut;
        }

        private void FadeIn()
        {
            CanvasGroup.DOKill();
            CanvasGroup.DOFade(1, 0.2f);
        }

        private void FadeOut()
        {
            CanvasGroup.DOKill();
            CanvasGroup.DOFade(0, 0.2f);
        }
    }
}