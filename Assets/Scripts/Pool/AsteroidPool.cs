using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Color_Em_Up
{
    public class AsteroidPool :PoolSystem<Asteroid>
    {
        private readonly List<Asteroid> activeAsteroids = new List<Asteroid>();
        
        private GameObject asteroidParent;
        
        public override void Initialized()
        {
            base.Initialized();

            asteroidParent = new GameObject("_Asteroids_")
            {
                transform = { position = Vector3.zero }
            };
        }
        
        protected override Asteroid CreateObject()
        {
            var _asteroid = Instantiate(Prefab, Vector3.zero, Quaternion.identity, asteroidParent.transform);
            
            _asteroid.SetPool(Pool);
            _asteroid.Initialized();
            
            return _asteroid;
        }

        protected override void OnGetObject(Asteroid _asteroid)
        {
            _asteroid.gameObject.SetActive(true);
            activeAsteroids.Add(_asteroid);
        }

        protected override void OnRelease(Asteroid _asteroid)
        {
            _asteroid.gameObject.SetActive(false);
        }

        protected override void OnObjectDestroyed(Asteroid _asteroid)
        {
            Destroy(_asteroid.gameObject);
        }

        public override void ClearPool()
        {
            if (activeAsteroids.Count > 0)
            {
                activeAsteroids.ForEach(_placement => _placement.ReturnToPool());
                activeAsteroids.Clear();
            }
        }
    }
}
