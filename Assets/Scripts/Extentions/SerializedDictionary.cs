using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Extentions
{
    [Serializable]
    public class SerializedDictionary<TKey, TValue>
    {
        [SerializeField] private List<SerializedKeyValuePair<TKey, TValue>> _pairs;
        private Dictionary<TKey, TValue> _dictionary;

        public Dictionary<TKey, TValue> Dictionary => _dictionary ??= 
            _pairs.ToDictionary(pair => pair.Key, pair => pair.Value);
    }

    [Serializable]
    public class SerializedKeyValuePair<TKey, TValue>
    {
        [SerializeField] private TKey _key;
        [SerializeField] private TValue _value;

        public TKey Key => _key;
        public TValue Value => _value;
    }
}