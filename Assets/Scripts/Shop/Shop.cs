using System.Collections;
using Content;
using RunProgress;
using UnityEngine;

namespace Shop
{
    public class Shop : MonoBehaviour
    {
        [SerializeField] private ShopStage<ModifiedStat> _statStage;
        [SerializeField] private ShopStage<WeaponDetails> _weaponPurchaseStage;
        [SerializeField] private ShopStage<PlayerWeapon> _weaponUpgradeStage;
        
        private void Start()
        {
            StartCoroutine(ShopSequence());
        }

        private IEnumerator ShopSequence()
        {
            yield return StartCoroutine(_statStage.StartSelection());
            yield return StartCoroutine(_weaponPurchaseStage.StartSelection(3));
            yield return StartCoroutine(_weaponUpgradeStage.StartSelection());
        }
    }
}