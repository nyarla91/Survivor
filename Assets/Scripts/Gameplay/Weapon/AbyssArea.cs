using Extentions;
using Extentions.Factory;
using Gameplay.Units;
using UnityEngine;

namespace Gameplay.Weapon
{
    public class AbyssArea : PooledObject
    {
        [SerializeField] private OverlapTrigger2D _enemies;
        [SerializeField] private float _damagePeriod;
        
        private Timer _cooldown;
        private Timer _lifetime;
        private float _dps;
        
        public void Init(Pause pause, float dps, float duration)
        {
            _dps = dps;
            _cooldown = new Timer(this, _damagePeriod, pause, true).Start();
            _cooldown.OnExpire += DealDamage;
            _lifetime = new Timer(this, duration, pause).Start();
            _lifetime.OnExpire += PoolDisable;
        }

        private void DealDamage()
        {
            Hitbox[] targets = _enemies.GetContent<Hitbox>(LayerMask.GetMask("Enemy"));
            targets.Foreach(target => target.TakeHit(new Hit(_dps * _damagePeriod)));
        }

        public override void PoolDisable()
        {
            base.PoolDisable();
            _cooldown = null;
            _lifetime = null;
        }
    }
}