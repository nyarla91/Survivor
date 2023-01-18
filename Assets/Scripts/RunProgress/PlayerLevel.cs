using System;
using Extentions;
using UnityEngine;

namespace RunProgress
{
    public class PlayerLevel : MonoBehaviour
    {
        [SerializeField] private Resource _experience;

        public ResourceFacade Experience => _experience.Facade;

        public int UpgradePoints { get; private set; }

        public void AddOneExperience()
        {
            _experience.Value++;
            if (_experience.IsUnfilled)
                return;
            _experience.Value = 0;
            _experience.MaxValue = (int) _experience.MaxValue * 2f;
            UpgradePoints++;
        }

        public void DiscardPoints() => UpgradePoints = 0;
    }
}