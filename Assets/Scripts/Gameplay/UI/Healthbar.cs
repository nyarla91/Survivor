using Extentions;
using Gameplay.Units;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Gameplay.UI
{
    public class Healthbar : Transformable
    {
        [field: SerializeField] public HealthPool Target { get; set; }
        [SerializeField] private RectMask2D _mask;
        [SerializeField] private TMP_Text _counter;
        [SerializeField] private int _side;
        
        private void Start()
        {
            Target.OnHealthChanged += ApplyHealth;
            ApplyHealth(Target.Health, Target.MaxHealth);
        }

        private void ApplyHealth(float current, float max)
        {
            if (_counter != null)
                _counter.text = $"{Mathf.RoundToInt(current)}/{Mathf.RoundToInt(max)}";
            
            Rect rect = RectTransform.rect;
            float sidePadding = (_side.IsEven() ? rect.width : rect.height) * (1 - current / max);
            _mask.padding = new Vector4(GetSidePadding(0), GetSidePadding(1), GetSidePadding(2), GetSidePadding(3));

            float GetSidePadding(int side)
            {
                return _side == side ? sidePadding : 0;
            }
        }
    }
}