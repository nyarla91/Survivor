using Extentions;
using UnityEngine;
using Zenject;

namespace Gameplay.Units.Enemy
{
    public class EnemyContactAttack : MonoBehaviour
    {
        [SerializeField] private float _damagePerSecond;

        private Timer _cooldown;
        
        private OverlapTrigger2D Overlap { get; set; }

        [Inject] private Pause Pause { get; set; }

        private void Awake()
        {
            Overlap = GetComponent<OverlapTrigger2D>();
            _cooldown = new Timer(this, 1, Pause);
            _cooldown.Restart();
        }

        private void FixedUpdate()
        {
            if (_cooldown.IsOn || Overlap.Content.Length == 0)
                return;
            Hitbox[] targets = Overlap.GetContent<Hitbox>(LayerMask.GetMask("Player"));
            foreach (Hitbox target in targets)
            {
                target.TakeHit(new Hit(_damagePerSecond));
            }
            _cooldown.Restart();
        }
    }
}