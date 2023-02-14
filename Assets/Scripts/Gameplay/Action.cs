using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.Rendering;

public class Action : MonoBehaviour
{

    [SerializeField] RatSphere ratSphere;
    [SerializeField] Transform ratSpherePoint;
    [SerializeField] float timeToReload;
    private float timer;

    void Awake()
    {

    }
    void Update()

    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (Time.time > timer)
            {
                Instantiate(ratSphere, ratSpherePoint.position, Quaternion.Euler(Vector3.forward));
                timer = Time.time + timeToReload;
            }
        }
    }
}
