using Extentions;
using UnityEngine;

namespace Shop
{
    public class ShopCard<T> : LazyGetComponent<ShopCardView<T>> where T : class
    {
        [SerializeField] private CanvasGroup _canvasGroup;
        [SerializeField] private ShopStage<T> _stage;
        [SerializeField] private ShopCardView<T> _view;


        private T _currentObj;
        public void Show(T obj)
        {
            _canvasGroup.interactable = _canvasGroup.blocksRaycasts = true;
            Lazy.Show(obj);
        }

        public void Hide()
        {
            _canvasGroup.interactable = _canvasGroup.blocksRaycasts = false;
            Lazy.Hide();
        }

        protected void ChooseThis()
        {
            _stage.Choose(_currentObj);
        }
    }
}