using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Color_Em_Up
{
    public class SpawnPoint : MonoBehaviour
    {
        [field: SerializeField] public int PointCount { get; private set; } = 5;

        [SerializeField] private float XAxisInterval;
        [SerializeField] private float Height;
        [SerializeField] private Vector3 OriginOffset;
        
        [SerializeField] private int previousRandomIndex;

        [field: SerializeField] public List<Transform> SpawnPoints { get; private set; } = new List<Transform>();

        public Vector3 GetRandomPoint()
        {
            int _randRomIndex = Random.Range(0, SpawnPoints.Count);

            int _randomCount = 10;
            
            while (_randRomIndex == previousRandomIndex)
            {
                if(_randomCount <= 0)
                    break;
                
                _randRomIndex =  Random.Range(0, SpawnPoints.Count);
                _randomCount--;
            }

            previousRandomIndex = _randRomIndex;
            
            return SpawnPoints[_randRomIndex].position;
        }

        public void GenerateSpawnPoints()
        {
            ClearPoints();
            
            for (var _i = 0; _i < PointCount; _i++)
            {
                var _point = new Vector3(_i * XAxisInterval, Height, 0) + OriginOffset;

                var _pointObject = new GameObject($"_Point_{_i}")
                {
                    transform =
                    {
                        position = _point, 
                        parent   = this.transform
                    }
                };
                
                SpawnPoints.Add(_pointObject.transform);
            }
        }

        public void ClearPoints()
        {
            foreach (var _point in SpawnPoints)
            {
                if (Application.isPlaying)
                {
                    Destroy(_point.gameObject);
                    continue;
                }
                    
                #if UNITY_EDITOR
                DestroyImmediate(_point.gameObject);
                #endif
            }
            
            SpawnPoints.Clear();
        }

#if UNITY_EDITOR
        private void OnDrawGizmos()
        {
            if (SpawnPoints != null && SpawnPoints.Count > 0)
            {
                Gizmos.color = Color.yellow;
                
                foreach (var _point in SpawnPoints)
                {
                    Gizmos.DrawSphere(_point.position, 0.1f);
                }
            }
        }
#endif
    }
}
