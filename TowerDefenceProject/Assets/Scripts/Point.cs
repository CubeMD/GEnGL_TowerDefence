using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Point : MonoBehaviour
{
    public List<Point> previousPoints = new List<Point>();
    public Point nextPoint;

/*    public void DrawPath()
    {
        Debug.Log(name);
        foreach (Point previousPoint in previousPoints)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawLine(transform.position, previousPoint.transform.position);

            previousPoint.DrawPath();
        }
    }*/
}
