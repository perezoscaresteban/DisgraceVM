using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolDictionary: MonoBehaviour
{
    [SerializeField] private List<Transform> patrolPoints;
    private Dictionary<int, Transform> dictionaryPoints;
    private int nextPoint;

    void Awake()
    {
        dictionaryPoints = new Dictionary<int, Transform>();
        var index = 0;
        foreach (Transform e in transform)
        {
            dictionaryPoints.Add(index, e);
        }
    }

    public Transform NextPoint()
    {
        if (dictionaryPoints.ContainsKey(nextPoint))
        {
            var point = dictionaryPoints[nextPoint];
            nextPoint += 1;
            return point;
        }
        else
        {
            nextPoint = 0;
            return dictionaryPoints[nextPoint];
        }
    }
}
