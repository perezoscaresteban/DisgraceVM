using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UIElements;

public class Patrol : MonoBehaviour
{
    [SerializeField] private List<Transform> patrolPoints;
    private int nextPoint;
    private int lastIndex;

    void Awake()
    {
        nextPoint = 0;
        lastIndex = patrolPoints.Count-1;

    }

    public Transform NextPoint()
    {
        if (nextPoint < lastIndex)
        {
            nextPoint += 1;
        }
        else
        {
            patrolPoints.Reverse();
            nextPoint = 0;
        }
        return patrolPoints[nextPoint];
    }
}
