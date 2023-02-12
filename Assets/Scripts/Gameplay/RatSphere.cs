using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;



public class RatSphere : MonoBehaviour
{
    [SerializeField] float damage;
    [SerializeField] float time;

    void Awake()
    {

    }

    void Update()
    {

        if (time <= 0)
        {
            Destroy(gameObject, time);
        }
        else
        {
            time -= Time.deltaTime;
        }
    }
}
