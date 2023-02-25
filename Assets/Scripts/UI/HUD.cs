using System.Collections;
using System.Collections.Generic;
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

    public void UpdateHealth(float amount)
    {
        playerHealth = amount;
        healthBar.fillAmount = playerHealth/ playerMaxHealth;
    }

    public void UpdateMaxHealth(float amount)
    {
        playerMaxHealth = amount;
        //healthBar.fillAmount = playerHealth / playerMaxHealth;
    }

    public void UpdateCoins(float n)
    {
        coins.text = n.ToString();
    }


}
