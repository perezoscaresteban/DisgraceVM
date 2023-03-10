using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class OptionsMenu : MonoBehaviour
{
    public Toggle vsync;
    public Toggle fullScreen;

    public UnityEvent OnExit;
    void Start()
    {
        fullScreen.isOn = Screen.fullScreen;

        if (QualitySettings.vSyncCount == 0)
        {
            vsync.isOn = false;
        }
        else
        {
            vsync.isOn = true;
        }
    }

    public void ApplyGraphics() 
    {
        Screen.fullScreen = fullScreen.isOn;

        if (vsync.isOn)
        {
            QualitySettings.vSyncCount = 1;
        }
        else
        {
            QualitySettings.vSyncCount = 0;
        }
    }
}
