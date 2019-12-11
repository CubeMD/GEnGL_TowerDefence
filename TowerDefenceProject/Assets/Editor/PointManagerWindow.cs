using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace Editor
{
    public class PointManagerWindow : UnityEditor.EditorWindow
    {
        public Transform pointRoot;

        [MenuItem("Tools/point Manager")]
        public static void Open()
        {
            GetWindow<PointManagerWindow>();
        }

        private void OnGUI()
        {
            SerializedObject obj = new SerializedObject(this);

            EditorGUILayout.PropertyField(obj.FindProperty("pointRoot"));
            if (pointRoot == null)
            {
                EditorGUILayout.HelpBox("Root transform must be selected", MessageType.Warning);
            }
            else
            {
                if (GUILayout.Button("Create point"))
                {

                    if (Selection.activeGameObject && Selection.activeGameObject.GetComponent<Point>())
                    {
                        ContinuePoint(Selection.activeGameObject.GetComponent<Point>());
                    }
                    else
                    {
                        MakeNewPoint();
                    }
                }
            }

            obj.ApplyModifiedProperties();
        }

        private void ContinuePoint(Point prevPoint)
        {
            GameObject pointObject = new GameObject("point" + pointRoot.childCount, typeof(Point));

            pointObject.transform.SetParent(pointRoot,false);

            Point point = pointObject.GetComponent<Point>();

            point.nextPoint = prevPoint;
            prevPoint.previousPoints.Add(point);
            point.transform.position = prevPoint.transform.position;
            point.transform.forward = prevPoint.transform.forward;
            
            Selection.activeGameObject = point.gameObject;
        }
        
        private void MakeNewPoint()
        {
            GameObject pointObject = new GameObject("point" + pointRoot.childCount, typeof(Point));

            pointObject.transform.SetParent(pointRoot,false);

            Point point = pointObject.GetComponent<Point>();
            
            if (pointRoot.childCount > 1)
            {
                point.previousPoints.Add(pointRoot.GetChild(pointRoot.childCount - 2).GetComponent<Point>());
                point.previousPoints[0].nextPoint = point;
                point.transform.position = point.previousPoints[0].transform.position;
                point.transform.forward = point.previousPoints[0].transform.forward;
            }

            Selection.activeGameObject = point.gameObject;
        }
        
    }
}
