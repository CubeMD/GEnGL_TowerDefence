using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Point : MonoBehaviour
{
    public List<Point> previousPoints = new List<Point>();
    public Point nextPoint;
}
