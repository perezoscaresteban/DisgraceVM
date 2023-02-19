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
    [SerializeField] private GameObject player;
    private HealthController playerHealthController;
    [SerializeField] private TMP_Text coins;
    [SerializeField] private Image coin;
    //[SerializeField] TextMeshProUGUI coins;

    private void Awake()
    {
        playerHealthController = player.GetComponent<HealthController>();
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

    // Update is called once per frame
    void Update()
    {
        healthBar.fillAmount = playerHealthController.health / playerHealthController.maxHealth;
    }

    public void UpdateCoins(float n)
    {
        coins.text = n.ToString();
    }
}
