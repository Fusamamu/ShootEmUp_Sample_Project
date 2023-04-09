using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Color_Em_Up
{
    [Serializable]
    public class LevelData
    {
        public int WaveCount => WaveData.Count;
        
        public int LevelIndex;
        
        public List<WaveData> WaveData;

        public Color LevelBackgroundColor;
    }
}
