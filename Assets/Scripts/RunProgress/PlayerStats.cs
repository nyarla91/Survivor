using System;
using System.Collections.Generic;
using System.Linq;
using Extentions;
using UnityEngine;

namespace RunProgress
{
    public class PlayerStats : MonoBehaviour
    {
        [SerializeField] private SerializedDictionary<string, ModifiedStat> _stats;

        public ModifiedStat[] Stats => _stats.Dictionary.Select(pair => pair.Value).ToArray();

        public ModifiedStat GetStat(string key)
        {
            Dictionary<string, ModifiedStat> stats = _stats.Dictionary;
            if (!stats.ContainsKey(key))
                throw new ArgumentOutOfRangeException($"There is no {key} stat");
            return stats[key];
        }

        private void Awake() => _stats.Dictionary.Values.Foreach(stat => stat.Reset());
    }
}