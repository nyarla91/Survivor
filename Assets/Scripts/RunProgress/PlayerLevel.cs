using System;
using Extentions;
using UnityEngine;

namespace RunProgress
{
    public class PlayerLevel : MonoBehaviour
    {
        [SerializeField] private Resource _experience;
        
        private int _upgradePoints;

        public ResourceFacade Experience => _experience.Facade;

        public int UpgradePoints
        {
            get => _upgradePoints;
            set
            {
                if (value == _upgradePoints)
                    return;
                _upgradePoints = value;
                OnLevelChanged?.Invoke(_upgradePoints);
            }
        }

        public event Action<int> OnLevelChanged;

        public void AddOneExperience()
        {
            _experience.Value++;
            print(324);
            if (_experience.IsUnfilled)
                return;
            _experience.Value = 0;
            _experience.MaxValue = (int) _experience.MaxValue * 2f;
            UpgradePoints++;
        }
    }
}