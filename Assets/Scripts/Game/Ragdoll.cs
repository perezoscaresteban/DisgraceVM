using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Ragdoll : MonoBehaviour
{
    [SerializeField] private Animator animator;

    private Rigidbody[] rigidbodies;

    void Start()
    {
        rigidbodies = transform.GetComponentsInChildren<Rigidbody>();
        SetEnabled(false);
    }

    void SetEnabled(bool enabled)
    {
        bool isKinematic = !enabled;
        foreach (Rigidbody rigidbody in rigidbodies)
        {
            rigidbody.isKinematic = isKinematic;
        }

        animator.enabled = !enabled;
    }

    public void Activate() 
    {
        SetEnabled(true);
    }

}
