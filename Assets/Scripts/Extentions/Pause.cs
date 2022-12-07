﻿using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Extentions
{
    public class Pause : MonoBehaviour
    {
        private readonly List<MonoBehaviour> _pauseSources = new List<MonoBehaviour>();

        public bool IsPaused => _pauseSources.Where(source => source != null).ToArray().Length > 0;
        public bool IsUnpaused => ! IsPaused;
        
        public void AddPauseSource(MonoBehaviour source) => _pauseSources.Add(source);
        public void RemoveSource(MonoBehaviour source) => _pauseSources.TryRemove(source);
    }
}