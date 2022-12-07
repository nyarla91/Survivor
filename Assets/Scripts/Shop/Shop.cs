using System.Collections;
using UnityEngine;

namespace Shop
{
    public class Shop : MonoBehaviour
    {
        [SerializeField] private StatStage _statStage;
        
        private void Start()
        {
            StartCoroutine(ShopSequence());
        }

        private IEnumerator ShopSequence()
        {
            yield return StartCoroutine(_statStage.StartUpgrade());
            
        }
    }
}