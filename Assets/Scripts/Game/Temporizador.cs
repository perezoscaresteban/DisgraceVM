using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Temporizador : MonoBehaviour
{
    private float timeT;

    private void Update()
    {
        UpdateTimer();
    }

    private void UpdateTimer()
    {
        timeT += Time.deltaTime;
    }

    public float TimeAccount() 
    {
        return timeT;
    }

    public void ResetTimer() 
    {
        timeT = 0;
    }
}
