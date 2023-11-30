using System;
using System.Collections.Generic;
using Core.Pool;

namespace Core.Bullets
{
    [Serializable]
    public class BulletPool : MonoPool<Bullet>
    {
        public override void Release(Bullet bullet)
        {
            base.Release(bullet);
            bullet.transform.SetParent(Container);
            ActiveObject.Remove(bullet);
        }

        public override Bullet Get()
        {
            Bullet bullet = base.Get();
            bullet.transform.SetParent(WorldTransform);
            return bullet;
        }
        
        public void AddActiveObject(Bullet bullet)
        {
           ActiveObject.Add(bullet);
        }

        public IEnumerable<Bullet> GetActiveObject()
        {
            return ActiveObject;
        }
    }
}