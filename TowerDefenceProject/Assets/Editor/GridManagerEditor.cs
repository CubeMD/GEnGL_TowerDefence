using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(GridManager))]
public class GridManagerEditor : Editor
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
