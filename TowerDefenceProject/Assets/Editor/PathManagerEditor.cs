using System;
using UnityEditor;
using UnityEngine;


namespace Editor
{
    [CustomEditor(typeof(PathManager))]
    public class PathManagerEditor : UnityEditor.Editor
    {
        private void OnSceneGUI()
        {
            PathManager pathManagerScript = (PathManager) target;

            if (pathManagerScript.drawLine)
            {
                for (int i = 0; i < pathManagerScript.points.Count - 1; i++)
                {
                    Handles.DrawBezier(pathManagerScript.points[i],
                        pathManagerScript.tangents[i],
                        pathManagerScript.points[i + 1],
                        pathManagerScript.tangents[i + 1], Color.red, null, 2f);
                }
            }
        }

        public override void OnInspectorGUI()
        {
            PathManager pathManagerScript = (PathManager) target;

            if (GUILayout.Button("Add point"))
            {
                pathManagerScript.points.Add(Vector3.zero);
                pathManagerScript.tangents.Add(Vector3.zero);
            }

            if (GUILayout.Button("ToggleDraw"))
            {
                pathManagerScript.drawLine = !pathManagerScript.drawLine;
            }

            DrawDefaultInspector();
        }
    }
}
