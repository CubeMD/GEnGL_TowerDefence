using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Editor
{
    [CustomEditor(typeof(GridManager))]
    public class GridManagerEditor : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            GridManager gridManagerScript = (GridManager)target;
        
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

