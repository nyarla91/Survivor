using System;
using Content;
using UnityEngine;

namespace RunProgress
{
    [Serializable]
    public class Round
    {
        [field: SerializeField] public EnemySpawnCycle SpawnCycle { get; private set; }
        [field: SerializeField] public RoundWeaponAction WeaponAction { get; private set; }
        [field: SerializeField] [Tooltip("In seconds")] public float Length { get; private set; }
    }

    public enum RoundWeaponAction
    {
        Buy,
        Upgrade
    } 
}