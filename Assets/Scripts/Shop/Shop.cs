using System;
using System.Collections;
using Content;
using RunProgress;
using TMPro;
using UnityEngine;
using Zenject;

namespace Shop
{
    public class Shop : MonoBehaviour
    {
        [SerializeField] private TMP_Text _label;
        [SerializeField] private ShopStage<ModifiedStat> _statStage;
        [SerializeField] private ShopStage<WeaponDetails> _weaponPurchaseStage;
        [SerializeField] private ShopStage<PlayerWeapon> _weaponUpgradeStage;
        [SerializeField] private NextRoundButton _nextRoundButton;
        
        [Inject] private RunRounds RunRounds { get; set; }
        
        private void Start()
        {
            StartCoroutine(ShopSequence());
        }

        private IEnumerator ShopSequence()
        {
            yield return StartStage(_statStage);
            yield return RunRounds.CurrentRound.WeaponAction switch
            {
                RoundWeaponAction.Buy => StartStage(_weaponPurchaseStage),
                RoundWeaponAction.Upgrade => StartStage(_weaponUpgradeStage),
                _ => throw new ArgumentOutOfRangeException()
            };
            _nextRoundButton.Show();
        }

        private IEnumerator StartStage<T>(ShopStage<T> stage) where T : class
        {
            _label.text = stage.Label;
            yield return StartCoroutine(stage.StartSelection());
        }
    }
}