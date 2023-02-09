using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEditor.Rendering;
using UnityEngine;




public enum OutsiderState
{
    Idle,
    Pursuit,
    RunAway,
    Seeker
}

public enum OutsiderRotation { 
    Direct,
    Lerp
}


public class OutsiderController : MonoBehaviour
{

    [SerializeField] private Transform pj;
    [SerializeField] private OutsiderState currentState;
    [SerializeField] private float speed;
    [SerializeField] private float pursuitDistance;
    [SerializeField] private float rotationSpeed;
    private Vector3 pjPosition;

    public void SetCurrentState()
    {
        switch (currentState)
        {
            case OutsiderState.Idle:
                ExecuteIdle();
                break;
            case OutsiderState.Pursuit:
                ExecutePursuit();
                break;
            case OutsiderState.RunAway:
                ExecuteRunAway();
                break;
            case OutsiderState.Seeker:
                ExecuteSeeker();
                break;
            default:
                Debug.LogError("Current state is invalid");
                break;
        }
    }

    private void ExecuteIdle()
    {
    }

    private void ExecutePursuit()
    {
        var vectorToPJ = pj.position - transform.position;
        var distance = vectorToPJ.magnitude;
        if (distance < pursuitDistance)
        {
            Quaternion newRotation = Quaternion.LookRotation(pj.position - transform.position);
            transform.rotation = newRotation;
            transform.position += vectorToPJ.normalized * (speed * Time.deltaTime);
        }
    }

    private void ExecuteRunAway()
    {
        var vectorToPJ = transform.position - pj.position;
        var distance = vectorToPJ.magnitude;
        if (distance < pursuitDistance)
        {
            Quaternion newRotation = Quaternion.LookRotation(pj.position - transform.position);
            transform.rotation = newRotation;
            transform.position += vectorToPJ.normalized * (speed * Time.deltaTime);
        }

    }

    private void ExecuteSeeker()
    {
        Quaternion newRotation = Quaternion.LookRotation(pj.position - transform.position);
        transform.rotation = Quaternion.Lerp(transform.rotation,newRotation, Time.deltaTime * rotationSpeed);
    }

    private void Update()
    {
        SetCurrentState();
    }
}
