using System;
using UnityEngine;

namespace Extentions
{
    [Serializable]
    public class ResourceInt
    {
        [SerializeField] private bool _possibleNegative;
        [SerializeField] private int _value;
        [SerializeField] private int _maxValue;

        public int Value
        {
            get => _value;
            set
            {
                if (value > MaxValue)
                    OnGainExcess?.Invoke(value - MaxValue);
                value = _possibleNegative ? Mathf.Min(value, MaxValue) : Mathf.Clamp(value, 0, _maxValue);
                if (value.Equals(_value))
                    return;

                _value = value;
                OnChanged?.Invoke(value, Percent);
                if (_value == 0)
                    OnOver?.Invoke();
            }
        }

        public int MaxValue => _maxValue;

        public float Percent => (float) Value / (float) _maxValue;

        public delegate void ChangedHandler(int newValue, float newPercent);
        public event ChangedHandler OnChanged;
        public event Action OnOver;
        public event Action<int> OnGainExcess;

        public void IncreaseMax(int increase)
        {
            if (increase <= 0)
                return;
            _maxValue += increase;
            Value += increase;
        }
        public bool TrySpend(int value)
        {
            if (value > Value)
                return false;
            
            Value -= value;
            return true;
        }
        
        public static implicit operator int(ResourceInt r) => r.Value;
    }
}