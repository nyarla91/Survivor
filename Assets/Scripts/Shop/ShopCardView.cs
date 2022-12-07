using System;
using Extentions;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Object = UnityEngine.Object;

namespace Shop
{
    public abstract class ShopCardView<T> : LazyGetComponent<CanvasGroup> where T : class
    {
        [SerializeField] private Image _icon;
        [SerializeField] private TMP_Text _text;

        public void Show(T obj)
        {
            Lazy.alpha = 1;
            _text.text = GetDisplayText(obj);
            _icon.sprite = GetIcon(obj);
        }

        public void Hide()
        {
            Lazy.alpha = 0;
        }
        
        protected abstract string GetDisplayText(T obj);
        protected abstract Sprite GetIcon(T obj);
    }
}