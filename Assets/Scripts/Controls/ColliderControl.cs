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

        public void EnableCollider()
        {
            Collider.enabled = true;
        }
        
        public void DisableCollider()
        {
            Collider.enabled = false;
        }
    }
}
