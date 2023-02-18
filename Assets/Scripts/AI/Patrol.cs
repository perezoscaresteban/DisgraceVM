using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UIElements;

public class Patrol : MonoBehaviour
{
    [SerializeField] private List<Transform> patrolPoints;
    private int nextPoint;

    void Awake()
    {
        patrolPoints.Reverse();
        nextPoint = patrolPoints.Count;

    }

    public Transform NextPoint()
    {
        if (nextPoint > 0)
        {
            nextPoint -= 1;
        }
        else
        {
            patrolPoints.Reverse();
            nextPoint = patrolPoints.Count-1;
        }
        return patrolPoints[nextPoint];
    }
}
