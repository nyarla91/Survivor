﻿using Extentions;
using UnityEngine;

namespace Gameplay.Units.Character
{
    public class CharacterLevel : MonoBehaviour
    {
        [SerializeField] private Resource _experience;

        public ResourceFacade Experience => _experience.Facade;
    }
}