using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour
{
    public Toggle vsync;
    public Toggle fullScreen;

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
            Debug.Log(vsync);
        }
        else
        {
            QualitySettings.vSyncCount = 0;
            Debug.Log(vsync);
        }
    }
}
