using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Color_Em_Up
{
    public class ColliderControl : MonoBehaviour
    {
        [field: SerializeField] public Collider  Collider  { get; private set; }
        [field: SerializeField] public Rigidbody Rigidbody { get; private set; }
        
#if UNITY_EDITOR
        private void OnValidate()
        {
            if (gameObject.TryGetComponent<Collider>(out var _collider))
            {
                Collider = _collider;
            }
        }
#endif

        public void EnableColliderAfterSecond(float _seconds)
        {
            StartCoroutine(EnableColliderCoroutine(_seconds));
        }

        private IEnumerator EnableColliderCoroutine(float _seconds)
        {
            yield return new WaitForSeconds(_seconds);
            
            EnableCollider();
        }

        public ColliderControl EnableCollider()
        {
            Collider.enabled = true;
            return this;
        }
        
        public ColliderControl DisableCollider()
        {
            Collider.enabled = false;
            return this;
        }
    }
}
