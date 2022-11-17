using System;
using Extentions;
using Gameplay.Units;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Gameplay.UI
{
    public class ResourceBar : Transformable
    {
        [SerializeField] private ResourcesShowType _valueShowType;
        [SerializeField] private RectMask2D _mask;
        [SerializeField] private TMP_Text _counter;
        [SerializeField] private int _side;
        
        public void Init(ResourceFacade resource)
        {
            resource.OnChange += ApplyValue;
            ApplyValue(resource.Value, resource.MaxValue);
        }

        private void ApplyValue(float current, float max)
        {
            if (_counter != null)
            {
                _counter.text = _valueShowType switch
                {
                    ResourcesShowType.None => "",
                    ResourcesShowType.OnlyCurrent => $"{Mathf.RoundToInt(current)}",
                    ResourcesShowType.CurrentAndMax => $"{Mathf.RoundToInt(current)}/{Mathf.RoundToInt(max)}",
                    ResourcesShowType.Percent => $"{Mathf.RoundToInt(current / max * 100)}%",
                    _ => throw new ArgumentOutOfRangeException()
                };
            }
            
            Rect rect = RectTransform.rect;
            float sidePadding = (_side.IsEven() ? rect.width : rect.height) * (1 - current / max);
            _mask.padding = new Vector4(GetSidePadding(0), GetSidePadding(1), GetSidePadding(2), GetSidePadding(3));

            float GetSidePadding(int side)
            {
                return _side == side ? sidePadding : 0;
            }
        }

        private enum ResourcesShowType
        {
            None,
            OnlyCurrent,
            CurrentAndMax,
            Percent
        }
    }
}