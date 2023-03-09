using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rat : MonoBehaviour
{
    public Animator enemyAnimator;
    public float timer;
    private bool isReturning;

    private void Awake()
    {
        timer = 0;

    }

    void Update()
    {

        if (!isReturning && timer > 1f)
        {
            transform.rotation *= Quaternion.Euler(0, 180, 0);
            isReturning = true;
        }
        transform.position += transform.forward * 0.05f;
        timer += Time.deltaTime;
    }
}
