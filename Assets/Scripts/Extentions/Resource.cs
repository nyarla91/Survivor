using System;
using UnityEngine;

namespace Gameplay.Entity
{
    [Serializable]
    public class Resource
    {
        [SerializeField] private bool _possibleNegative;
        [SerializeField] private float _value;
        [SerializeField] private float _maxValue;

        public float Value
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

        public float MaxValue => _maxValue;

        public float Percent => Value / MaxValue;

        public delegate void ChangedHandler(float newValue, float newPercent);
        public event ChangedHandler OnChanged;
        public event Action OnOver;
        public event Action<float> OnGainExcess;

        public void IncreaseMax(float increase)
        {
            if (increase <= 0)
                return;
            _maxValue += increase;
            Value += increase;
        }

        public bool TrySpend(float value)
        {
            if (value > Value)
                return false;
            
            Value -= value;
            return true;
        }
        
        public static implicit operator float(Resource r) => r.Value;
    }
}