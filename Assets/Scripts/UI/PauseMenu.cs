using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PauseMenu : MonoBehaviour
{
    public UnityEvent OnUpgradeHabilities;

    public static PauseMenu Instance;
    public bool dontDestroyOnLoad;

    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;

    void Start()
    {
        HUD.OnPause += Pause;
    }


    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;

            if (dontDestroyOnLoad)
            {
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }

    public void UpgradeHabilities()
    {
        //TODO OnUpgradeHabilities?.Invoke();
    }

    void Pause() 
    {
        Debug.Log(GameIsPaused);
        if (GameIsPaused)
        {
            pauseMenuUI.SetActive(false);
            Time.timeScale = 1f;
            GameIsPaused = false;
        }
        else 
        {
            pauseMenuUI.SetActive(true);
            Time.timeScale = 0f;
            GameIsPaused = true;
        }
    }
}
