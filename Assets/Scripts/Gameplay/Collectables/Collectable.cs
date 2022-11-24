using Extentions.Factory;
using Gameplay.Units.Player;
using UnityEngine;

namespace Gameplay.Collectables
{
    public abstract class Collectable : PooledObject
    {
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (!other.TryGetComponent(out CharacterComposition character))
                return;
            OnCollect(character);
            PoolDisable();
        }

        protected abstract void OnCollect(CharacterComposition character);
    }
}