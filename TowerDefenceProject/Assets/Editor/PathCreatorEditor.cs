using System;
using UnityEditor;
using UnityEngine;


namespace Editor
{
    [CustomEditor(typeof(PathCreator))]
    public class PathCreatorEditor : UnityEditor.Editor
    {
        PathCreator _pathCreator;
        Path path;

        void Input()
        {
            Event guiEvent = Event.current;
            Vector3 mousePos = HandleUtility.GUIPointToWorldRay(guiEvent.mousePosition).origin;
            if (guiEvent.type == EventType.MouseDown && guiEvent.button == 0 && guiEvent.shift)
            {
                Undo.RecordObject(_pathCreator, "Add segment");
                path.AddSegment(mousePos);
            }
        }
        private void OnSceneGUI()
        {
            Input();
            for (int i = 0; i < path.NumSegments; i++)
            {
                Vector3[] points = path.GetPointsInSegment(i);
                Handles.DrawLine(points[1], points[0]);
                Handles.DrawLine(points[2], points[3]);
                Handles.DrawBezier(points[0], points[3], points[1], points[2], Color.blue, null, 2);
            }
            
            for (int i = 0; i < path.NumPoints; i++)
            {
                Vector3 newPos = Handles.FreeMoveHandle(path[i], Quaternion.identity, 0.1f, Vector3.zero,
                    Handles.CylinderHandleCap);
                if (path[i] != newPos)
                {
                    Undo.RecordObject(_pathCreator, "Move point");
                    path.MovePoint(i, newPos);
                }
            }
        }

        private void OnEnable()
        {
            _pathCreator = (PathCreator) target;
            if (_pathCreator.path == null)
            {
                _pathCreator.CreatePath();
            }

            path = _pathCreator.path;
        }
    }
}
