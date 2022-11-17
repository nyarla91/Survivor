using System;
using Extentions;
using Extentions.Factory;

namespace Factory
{
    public class PooledObject : Transformable
    {
        private PoolFactory _factory;

        public event Action<PooledObject> OnPoolDisable;

        public virtual void PoolInit(PoolFactory factory)
        {
            _factory = factory;
        }
        
        public virtual void Disable()
        {
            OnPoolDisable?.Invoke(this);
            if (_factory != null)
                _factory.DisableObject(this);
            else
                Destroy(gameObject);
        }
    }
}