using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Temporizador : MonoBehaviour
{

    /*
     INPUTS TIMER
     T -> On / Off
     Y -> Reset
     */
    [SerializeField] private float timerI;
    private float timer;
    private bool active;

    // Start is called before the first frame update
    void Start()
    {
        timer = timerI;
    }

    // Update is called once per frame
    private void Update()
    {
        OnOff();
        UpdateTimer();
        ResetTimer();
        Debug.Log(timer);
    }

    private void OnOff()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            if (active) 
            { 
                active = false;
            }
            else
            {
                active = true;
            }
        }
    }

    private void UpdateTimer()
    {
        if (active && timer >= 0)
        {
            timer -= Time.deltaTime;
        }
    }

    private void ResetTimer() 
    {
        if (Input.GetKeyDown(KeyCode.Y))
        {
            timer = timerI;
            active = false;
        }
    }

}
