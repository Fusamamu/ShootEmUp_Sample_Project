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
        
        public float TimeLength;

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
