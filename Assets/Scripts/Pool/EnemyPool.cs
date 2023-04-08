using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Color_Em_Up
{
    public class EnemyPool : PoolSystem<Enemy>
    {
        private readonly List<Enemy> activeEnemies = new List<Enemy>();
        
        private GameObject enemyParent;
        
        public override void Initialized()
        {
            base.Initialized();

            enemyParent = new GameObject("_Enemy_")
            {
                transform = { position = Vector3.zero }
            };
        }
        
        protected override Enemy CreateObject()
        {
            var _enemy = Instantiate(Prefab, Vector3.zero, Quaternion.Euler(new Vector3(0, 180, 0)), enemyParent.transform);

            _enemy.name = $"Enemy";
            
            _enemy.SetPool(Pool);
            _enemy.Initialized();
            
            return _enemy;
        }

        protected override void OnGetObject(Enemy _enemy)
        {
            _enemy.gameObject.SetActive(true);
            _enemy.IsInPool = false;
            
            activeEnemies.Add(_enemy);
        }

        protected override void OnRelease(Enemy _enemy)
        {
            _enemy.ColliderControl.Rigidbody.velocity = Vector3.zero;
            _enemy.IsInPool = true;
            _enemy.gameObject.SetActive(false);
        }

        protected override void OnObjectDestroyed(Enemy _enemy)
        {
            Destroy(_enemy.gameObject);
        }

        public override void ClearPool()
        {
            if (activeEnemies.Count > 0)
            {
                activeEnemies.ForEach(_placement => _placement.ReturnToPool());
                activeEnemies.Clear();
            }
        }
    }
}
