using System;
using Extentions;
using Extentions.Factory;

namespace Factory
{
    public class PooledObject : Transformable
    {
        private PoolFactory _factory;

        public event Action<PooledObject> OnPooledDisable;

        public virtual void PoolInit(PoolFactory factory)
        {
            _factory = factory;
        }
        
        public virtual void Disable()
        {
            OnPooledDisable?.Invoke(this);
            if (_factory != null)
                _factory.DisableObject(this);
            else
                Destroy(gameObject);
        }
    }
}