using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    [SerializeField] Image healthBar;
    [SerializeField] GameObject player;
    private HealthController playerHealthController;
    //[SerializeField] TextMeshProUGUI coins;

    private void Awake()
    {
        playerHealthController = player.GetComponent<HealthController>();
    }

    // Update is called once per frame
    void Update()
    {
        healthBar.fillAmount = playerHealthController.health / playerHealthController.maxHealth;
        //coins.text = GameManager.Instance.coins.ToString();
    }
}
