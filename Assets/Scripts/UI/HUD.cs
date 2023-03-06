using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HUD : MonoBehaviour
{
    public static HUD Instance;
    public bool dontDestroyOnLoad;

    [SerializeField] private Image healthBar;
    private float playerHealth;
    private float playerMaxHealth;

    [SerializeField] private Image coin;
    [SerializeField] private TMP_Text coins;

    public PauseMenu pauseMenu;


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

    private void Start()
    {
        PlayerHealthController.OnMaxHealthChange += UpdateMaxHealth;
        PlayerHealthController.OnHealthChange += UpdateHealth;
    }

    public void UpdateHealth(float amount)
    {
        playerHealth = amount;
        healthBar.fillAmount = playerHealth/ playerMaxHealth;
    }

    public void UpdateMaxHealth(float amount)
    {
        playerMaxHealth = amount;
    }

    public void UpdateCoins(float n)
    {
        coins.text = n.ToString();
    }

    public void Pause()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        pauseMenu.Pause();
    }
}
