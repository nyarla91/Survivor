using System;
using System.Collections.Generic;
using Extentions;
using UnityEngine;

public static class Pause
{
    private static List<MonoBehaviour> _sources = new List<MonoBehaviour>();
    public static bool Paused => _sources.Count > 0;
    public static bool Unpaused => !Paused;

    public static void AddPauseSource(MonoBehaviour source) => _sources.Add(source);
    public static void RemovePauseSource(MonoBehaviour source) => _sources.TryRemove(source);
    public static void ClearPause() => _sources = new List<MonoBehaviour>();
}
