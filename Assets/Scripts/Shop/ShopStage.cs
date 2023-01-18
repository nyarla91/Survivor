using System;
using System.Collections;
using Extentions;
using UnityEngine;

namespace Shop
{
    public abstract class ShopStage<T> : LazyGetComponent<CanvasGroup> where T : class
    {
        [SerializeField] private string _label;
        [SerializeField] private ShopCard<T>[] _cards;

        private T _chosenObj;

        protected abstract T[] ObjPool { get; }
        protected virtual int Iterations => 1;

        public string Label => _label;
        
        public void Choose(T chosen)
        {
            if (_chosenObj != null)
                return;
            _chosenObj = chosen;
        }

        public IEnumerator StartSelection()
        {
            yield return StartCoroutine(StartSelection(Iterations));
        }
        
        public IEnumerator StartSelection(int iterations)
        {
            if (iterations <= 0)
                yield break;

            if (ObjPool.Length < _cards.Length)
                throw new Exception($"Not enough objects in {this} pool");
            
            Lazy.blocksRaycasts = true;
            Lazy.alpha = 1;
            for (int i = 0; i < iterations; i++)
            {
                T[] suggestedItems = ObjPool.PickRandomElements(_cards.Length).ToArray();
                for (int card = 0; card < _cards.Length; card++)
                {
                    _cards[card].InitObj(suggestedItems[card]);
                }
                _chosenObj = null;
                yield return new WaitUntil(() => _chosenObj != null);
                ProcessChosenObj(_chosenObj);
            }
            Lazy.blocksRaycasts = false;
            Lazy.alpha = 0;
            OnStageEnd();
        }

        protected virtual void OnStageEnd() { }

        protected abstract void ProcessChosenObj(T obj);
    }
}