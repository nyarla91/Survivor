using System;
using UnityEngine;
using Object = UnityEngine.Object;

namespace RunProgress
{
    [Serializable]
    public class ModifiedStat
    {
        [SerializeField] private string _displayName;
        [SerializeField] private string _displaySuffix;
        [SerializeField] private Sprite _icon;
        [SerializeField] private int _startingValue;
        [SerializeField] private int _amplificationPerLevel;

        public string DisplayName => _displayName;
        public string DisplaySuffix => _displaySuffix;
        public Sprite Icon => _icon;
        public int AmplificationPerLevel => _amplificationPerLevel;
        
        public int Value { get; private set; }
        public float PercentValue => Value * 0.01f;

        public void Reset() => Value = _startingValue;

        public void Upgrade() => Value += _amplificationPerLevel;
    }
}