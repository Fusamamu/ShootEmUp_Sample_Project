using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Color_Em_Up
{
    public class ParticlePool : PoolSystem<GameParticle>
    {
        private readonly List<GameParticle> activeParticles = new List<GameParticle>();

        private GameObject particleParent;
        
        public override void Initialized()
        {
            base.Initialized();

            particleParent = new GameObject("_Particles_")
            {
                transform = { position = Vector3.zero }
            };
        }
        
        protected override GameParticle CreateObject()
        {
            var _particle = Instantiate(Prefab, Vector3.zero, Quaternion.identity, particleParent.transform);
            _particle.Initialized();
            _particle.SetPool(Pool);
            
            return _particle;
        }

        protected override void OnGetObject(GameParticle _particle)
        {
            _particle.gameObject.SetActive(true);
            activeParticles.Add(_particle);
        }

        protected override void OnRelease(GameParticle _particle)
        {
            _particle.gameObject.SetActive(false);
        }

        protected override void OnObjectDestroyed(GameParticle _particle)
        {
            Destroy(_particle.gameObject);
        }

        public override void ClearPool()
        {
            if (activeParticles.Count > 0)
            {
                activeParticles.ForEach(_placement => _placement.ReturnToPool());
                activeParticles.Clear();
            }
        }
    }
}
