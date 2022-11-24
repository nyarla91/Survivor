using System;
using Extentions;
using UnityEngine;

namespace RunProgress
{
    public class PlayerLevel : MonoBehaviour
    {
        [SerializeField] private Resource _experience;
        private int _level;

        public ResourceFacade Experience => _experience.Facade;

        public int Level
        {
            get => _level;
            set
            {
                if (value == _level)
                    return;
                _level = value;
                OnLevelChanged?.Invoke(_level);
            }
        }

        public event Action<int> OnLevelChanged;

        public void AddOneExperience()
        {
            _experience.Value++;
            if (_experience.IsFull)
            {
                _experience.Value = 0;
                _experience.MaxValue = (int) _experience.MaxValue * 2f;
                Level++;
            }
        }
    }
}