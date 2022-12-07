using UnityEngine;

namespace RunProgress
{
    public class RunRounds : MonoBehaviour
    {
        [SerializeField] private Round[] _rounds;

        private int _currentRoundsIndex;

        public Round CurrentRound => _rounds[_currentRoundsIndex];

        public void NextRound() => _currentRoundsIndex++;
    }
}