using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera2 : MonoBehaviour
{
    [SerializeField] Transform cameraPosition = null;

    void Update()
    {
        transform.position = cameraPosition.position;
    }
}