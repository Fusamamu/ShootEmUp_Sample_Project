using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Color_Em_Up
{
    public class BulletPool : PoolSystem<Bullet>
    {
        private readonly List<Bullet> activeBullets = new List<Bullet>();

        private GameObject bulletParent;
        
        public override void Initialized()
        {
            base.Initialized();

            bulletParent = new GameObject("_Bullets_")
            {
                transform = { position = Vector3.zero }
            };
        }
        
        protected override Bullet CreateObject()
        {
            var _bullet = Instantiate(Prefab, Vector3.zero, Quaternion.identity, bulletParent.transform);
            _bullet.Initialized();
            _bullet.SetPool(Pool);
            
            return _bullet;
        }

        protected override void OnGetObject(Bullet _bullet)
        {
            _bullet.gameObject.SetActive(true);
            activeBullets.Add(_bullet);
        }

        protected override void OnRelease(Bullet _bullet)
        {
            _bullet.ColliderControl.Rigidbody.velocity = Vector3.zero;
            _bullet.gameObject.SetActive(false);
        }

        protected override void OnObjectDestroyed(Bullet _bullet)
        {
            Destroy(_bullet.gameObject);
        }

        public override void ClearPool()
        {
            if (activeBullets.Count > 0)
            {
                activeBullets.ForEach(_placement => _placement.ReturnToPool());
                activeBullets.Clear();
            }
        }
    }
}
