using System.Collections;
using Extentions;
using UnityEngine;

namespace Shop
{
    public abstract class ShopStage<T> : MonoBehaviour where T : class
    {
        [SerializeField] private string _label;
        [SerializeField] private ShopCard<T>[] _cards;

        private T _chosenObj;

        protected abstract T[] ObjPool { get; }
        protected virtual int Iterations => 1;
        
        public void Choose(T chosen)
        {
            if (_chosenObj != null)
                _chosenObj = chosen;
        }

        public IEnumerator StartUpgrade()
        {
            yield return StartCoroutine(StartUpgrade(Iterations));
        }
        
        public IEnumerator StartUpgrade(int iterations)
        {
            if (iterations <= 0)
                yield break;

            for (int i = 0; i < iterations; i++)
            {
                T[] suggestedStats = ObjPool.PickRandomElements(_cards.Length).ToArray();
                for (int card = 0; card < _cards.Length; card++)
                {
                    _cards[card].Show(suggestedStats[card]);
                }
                _chosenObj = null;
                yield return new WaitUntil(() => _chosenObj != null);
                ProcessChosenObj(_chosenObj);
            }
            _cards.Foreach(card => card.Hide());
        }

        protected abstract void ProcessChosenObj(T obj);
    }
}