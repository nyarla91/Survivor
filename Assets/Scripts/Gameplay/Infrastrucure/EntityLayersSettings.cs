using System.Collections.Generic;
using Extentions;
using UnityEngine;

namespace Gameplay.Infrastrucure
{
    [CreateAssetMenu(menuName = "Entity Layers")]
    public class EntityLayersSettings : ScriptableObject
    {
        [SerializeField] private SerializedDictionary<EntityOwner, int> _layers;

        public Dictionary<EntityOwner, int> Layers => _layers.Dictionary;
    }
}