using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Editor
{
    [CustomEditor(typeof(GridManager))]
    public class GridManagerEditor : UnityEditor.Editor
    {
        private GridManager gridManagerScript;
        public void OnEnable()
        {
            gridManagerScript = (GridManager)target;
        }

        public override void OnInspectorGUI()
        {
            if(GUILayout.Button("PlaceTiles"))
            {
                gridManagerScript.PlaceTiles();
            }
            if(GUILayout.Button("ClearTiles"))
            {
                gridManagerScript.ClearTiles();
            }
        
            DrawDefaultInspector();
        }
    }
}

