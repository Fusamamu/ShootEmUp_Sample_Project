using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Color_Em_Up
{
    [Serializable]
    public class WaveData
    {
        public int EnemyGroupCount => EnemyData.Count;
        
        public float TimeLength {

            get
            {
                var _totalTimeLength = 0f;

                foreach (var _enemyData in EnemyData)
                {
                    var _totalEnemySpawnTime = _enemyData.EnemyCount * _enemyData.SpawnInterval;
                    _totalTimeLength += _totalEnemySpawnTime;
                }

                return _totalTimeLength * 2 + NextWaveDelay;
            }
        }
        public float NextWaveDelay;

        public List<EnemyData> EnemyData;
    }

    [Serializable]
    public class EnemyData
    {
        public int EnemyCount;
        public EnemyType Type;
        public float SpawnInterval;
    }
}
