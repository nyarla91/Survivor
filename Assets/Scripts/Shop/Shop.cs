using System.Collections;
using Content;
using RunProgress;
using TMPro;
using UnityEngine;

namespace Shop
{
    public class Shop : MonoBehaviour
    {
        [SerializeField] private TMP_Text _label;
        [SerializeField] private ShopStage<ModifiedStat> _statStage;
        [SerializeField] private ShopStage<WeaponDetails> _weaponPurchaseStage;
        [SerializeField] private ShopStage<PlayerWeapon> _weaponUpgradeStage;
        [SerializeField] private NextWaveButton _nextWaveButton;
        
        private void Start()
        {
            StartCoroutine(ShopSequence());
        }

        private IEnumerator ShopSequence()
        {
            yield return StartStage(_statStage);
            yield return StartStage(_weaponPurchaseStage);
            yield return StartStage(_weaponPurchaseStage);
            yield return StartStage(_weaponPurchaseStage);
            yield return StartStage(_weaponUpgradeStage);
            _nextWaveButton.Show();
        }

        private IEnumerator StartStage<T>(ShopStage<T> stage) where T : class
        {
            _label.text = stage.Label;
            yield return StartCoroutine(stage.StartSelection());
        }
    }
}