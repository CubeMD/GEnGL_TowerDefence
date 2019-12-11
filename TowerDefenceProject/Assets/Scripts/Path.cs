using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Path
{
    public List<Vector3> points;

    public Path(Vector3 centre)
    {
        points = new List<Vector3>();
        points.Add(centre + Vector3.left);
        points.Add(centre + Vector3.left + Vector3.forward);
        points.Add(centre + Vector3.right + Vector3.down);
        points.Add(centre + Vector3.right);
    }

    public Vector3 this[int i]
    {
        get
        {
            return points[i];
        }
    }

    public int NumPoints
    {
        get
        {
            return points.Count;
        }
    }
    
    public int NumSegments
    {
        get
        {
            return (points.Count - 4) / 3 + 1;
        }
    }
    
    public void AddSegment(Vector3 anchor)
    {
        points.Add(points[points.Count - 1] * 2 - points[points.Count - 2]);
        points.Add(points[points.Count - 1] + anchor);
        points.Add(anchor);
    }

    public Vector3[] GetPointsInSegment(int i)
    {
        return new Vector3[] {points[i * 3], points[i * 3 + 1], points[i * 3 + 2], points[i * 3 + 3] };
    }

    public void MovePoint(int i, Vector3 pos)
    {
        points[i] = pos;
    }
}
