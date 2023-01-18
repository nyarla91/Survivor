using System;
using Gameplay.Round;
using TMPro;
using UnityEngine;

namespace Gameplay.UI
{
    public class RoundTimer : MonoBehaviour
    {
        [SerializeField] private RoundCountdown _countdown;
        [SerializeField] private TMP_Text _text;

        private void Update()
        {
            _text.text = Mathf.CeilToInt(_countdown.TimeLeft).ToString();
        }
    }
}