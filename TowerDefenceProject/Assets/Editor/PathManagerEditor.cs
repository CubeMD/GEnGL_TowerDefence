using System;
using UnityEditor;
using UnityEngine;


namespace Editor
{
    [CustomEditor(typeof(PathManager))]
    public class PathManagerEditor : UnityEditor.Editor
    {
        private PathManager pathManagerScript;
        
        private void OnEnable()
        {
            pathManagerScript = (PathManager) target;
            
            if (pathManagerScript.path == null)
            {
                pathManagerScript.CreatePath();
            }
        }
        
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
            
            Input();
            for (int i = 0; i < pathManagerScript.path.NumSegments; i++)
            {
                Vector3[] points = pathManagerScript.path.GetPointsInSegment(i);
                Handles.DrawLine(points[1], points[0]);
                Handles.DrawLine(points[2], points[3]);
                Handles.DrawBezier(points[0], points[3], points[1], points[2], Color.blue, null, 2);
            }
            
            for (int i = 0; i < pathManagerScript.path.NumPoints; i++)
            {
                Vector3 newPos = Handles.FreeMoveHandle(pathManagerScript.path[i], Quaternion.identity, 0.1f, Vector3.zero,
                    Handles.CylinderHandleCap);
                if (pathManagerScript.path[i] != newPos)
                {
                    Undo.RecordObject(pathManagerScript, "Move point");
                    pathManagerScript.path.MovePoint(i, newPos);
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
        
        

        void Input()
        {
            Event guiEvent = Event.current;
            Vector3 mousePos = HandleUtility.GUIPointToWorldRay(guiEvent.mousePosition).origin;
            if (guiEvent.type == EventType.MouseDown && guiEvent.button == 0 && guiEvent.shift)
            {
                Undo.RecordObject(pathManagerScript, "Add segment");
                pathManagerScript.path.AddSegment(mousePos);
            }
        }
    }
}
