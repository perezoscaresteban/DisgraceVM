using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Temporizador : MonoBehaviour
{
    private float timeI;

    private void Update()
    {
        UpdateTimer();
    }

    private void UpdateTimer()
    {
        timeI += Time.deltaTime;
    }

    public float timeAccount() 
    {
        return timeI;
    }
}
