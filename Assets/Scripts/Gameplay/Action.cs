using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.Rendering;

public class Action : MonoBehaviour
{

    [SerializeField] RatSphere ratSphere;
    [SerializeField] Transform place;
    [SerializeField] float timeToReload;

    void Awake()
    {

    }
    void Update()

    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (Time.time - timeToReload > 0)
            {
                Instantiate(ratSphere, place.position, Quaternion.Euler(Vector3.forward));
                timeToReload += Time.time;
            }
        }
    }
}
