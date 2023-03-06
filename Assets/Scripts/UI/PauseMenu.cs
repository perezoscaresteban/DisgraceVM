using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public UnityEvent OnUpgradePowers;

    public bool gameIsPaused = false;

    void Start()
    {

    }


    private void Awake()
    {

    }

    public void UpgradePowers()
    {
        //TODO OnUpgradeHabilities?.Invoke();
    }

    public void Pause() 
    {
        if (gameIsPaused)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            gameObject.SetActive(false);
            Time.timeScale = 1f;
            gameIsPaused = false;
        }
        else 
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            gameObject.SetActive(true);
            Time.timeScale = 0f;
            gameIsPaused = true;
        }
    }

    public void Quit()
    {
        SceneManager.LoadScene("Menu");
    }
}
