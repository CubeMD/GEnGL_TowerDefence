using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace Editor
{
    public class PointEditor 
    {
        [DrawGizmo((GizmoType.NonSelected | GizmoType.Selected | GizmoType.Pickable))]
        public static void OnDrawSceneGizmo(Point point, GizmoType gizmoType)
        {
            if ((gizmoType & GizmoType.Selected) != 0)
            {

                Gizmos.color = Color.yellow;
            }
            else
            {
                Gizmos.color = Color.yellow * 0.5f;
            }

            Gizmos.DrawSphere(point.transform.position, 0.5f);

            Gizmos.color = Color.magenta;
            
            foreach (Point previousPoint in point.previousPoints)
            {
                Gizmos.DrawLine(point.transform.position, previousPoint.transform.position);
            }

        }
        
        
    }
}
