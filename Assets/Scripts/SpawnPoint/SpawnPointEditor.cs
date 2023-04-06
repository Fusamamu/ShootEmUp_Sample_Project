#if UNITY_EDITOR
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace Color_Em_Up
{
    [CustomEditor(typeof(SpawnPoint))]
    public class SpawnPointEditor : Editor
    {
        private SpawnPoint spawnPoint;

        private void OnEnable()
        {
            spawnPoint = (SpawnPoint)target;
        }

        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();

            if (GUILayout.Button("Generate Spawn Point"))
            {
                spawnPoint.GenerateSpawnPoints();
                EditorUtility.SetDirty(spawnPoint);
            }
            
            if (GUILayout.Button("Clear Points"))
            {
                spawnPoint.ClearPoints();
                EditorUtility.SetDirty(spawnPoint);
            }
        }
    }
}
#endif
