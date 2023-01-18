using Extentions;
using Gameplay.UI;
using RunProgress;
using UnityEngine;
using Zenject;

namespace Gameplay.Round
{
    public class RoundCountdown : MonoBehaviour
    {
        [SerializeField] private RoundEndScreen _roundEndScreen;
        
        public Timer _countdown;
        public float TimeLeft => _countdown.TimeLeft;
        
        [Inject]
        private void Construct(RunRounds rounds, Pause pause)
        {
            _countdown = new Timer(this, rounds.CurrentRound.Length, pause).Start();
            _countdown.OnExpire += EndWave;
        }

        private void EndWave()
        {
            _roundEndScreen.Open();
        }
    }
}