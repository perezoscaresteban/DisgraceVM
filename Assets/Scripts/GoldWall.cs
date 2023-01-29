using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldWall : MonoBehaviour
{
    public GameObject temporizador;
    private Temporizador temporizadorI;
    [SerializeField] private Transform[] newPositions;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("ENTER");
    }


    private void OnTriggerStay(Collider other)
    {
        var l_controlScript = other.GetComponent<ControlScript>();
        if (l_controlScript != null && temporizadorI == null)
        {
            temporizadorI = Instantiate(temporizador).GetComponent<Temporizador>();
        }
        else
        {
            if (temporizadorI != null && temporizadorI.timeAccount()>= 2)
            {
                var newPositionYRotation = GetPosition();
                var newPosition = newPositionYRotation.localPosition;
                var newRotation = newPositionYRotation.localRotation;
                transform.localPosition = newPosition;
                transform.localRotation = newRotation;
                Destroy(temporizadorI); 
                temporizadorI = null;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {

    }

    public Transform GetPosition() 
    {
        return newPositions[Random.Range(0, newPositions.Length)];
    }
}
