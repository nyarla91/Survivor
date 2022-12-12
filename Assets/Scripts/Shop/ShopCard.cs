using Extentions;
using UnityEngine;

namespace Shop
{
    public class ShopCard<T> : LazyGetComponent<ShopCardView<T>> where T : class
    {
        [SerializeField] private ShopStage<T> _stage;
        [SerializeField] private ShopCardView<T> _view;


        private T _currentObj;
        public void InitObj(T obj)
        {
            _currentObj = obj;
            Lazy.Show(obj);
        }

        public void ChooseThis()
        {
            _stage.Choose(_currentObj);
        }
    }
}