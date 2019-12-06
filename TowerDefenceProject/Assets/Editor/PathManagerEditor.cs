using System;
using UnityEditor;
using UnityEngine;


namespace Editor
{
    [CustomEditor(typeof(PathManager))]
    public class PathManagerEditor : UnityEditor.Editor
    {
        bool drawLine;

        private void OnSceneGUI()
        {
            Debug.Log("");
            PathManager pathManagerScript = (PathManager) target;

            if (drawLine)
            {
                for (int i = 0; i < pathManagerScript.points.Count - 1; i++)
                {
                    Handles.DrawBezier(pathManagerScript.points[i].transform.position,
                        pathManagerScript.points[i + 1].transform.position,
                        pathManagerScript.points[i + 1].transform.position,
                        pathManagerScript.points[i].transform.position, Color.red, null, 2f);
                }
            }
        }

        public override void OnInspectorGUI()
        {
            PathManager pathManagerScript = (PathManager) target;

            if (GUILayout.Button("Add point"))
            {
                GameObject point = new GameObject();
                point.transform.parent = pathManagerScript.transform;
                pathManagerScript.points.Add(point);
            }

            if (GUILayout.Button("ToggleDraw"))
            {
                drawLine = !drawLine;
            }

            DrawDefaultInspector();
        }
    }
}
