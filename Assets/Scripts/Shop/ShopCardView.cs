using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Shop
{
    public abstract class ShopCardView<T> : MonoBehaviour where T : class
    {
        [SerializeField] private Image _icon;
        [SerializeField] private TMP_Text _text;

        public void Show(T obj)
        {
            _text.text = GetDisplayText(obj);
            _icon.sprite = GetIcon(obj);
        }
        
        protected abstract string GetDisplayText(T item);
        protected abstract Sprite GetIcon(T item);
    }
}