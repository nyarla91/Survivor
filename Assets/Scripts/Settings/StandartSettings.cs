using UnityEngine;

namespace Settings
{
    [UnityEngine.CreateAssetMenu(menuName = "Standart Settings", order = 0)]
    public class StandartSettings : ScriptableObject
    {
        [field: SerializeField] public SettingsConfig Config { get; private set; }
    }
}