using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameUI : MonoBehaviour
{
    [SerializeField] Image UIHealthBar;
    //[SerializeField][Range(0, 1)] float UIHealthBarVal;

    [SerializeField] GameObject player;
    private PlayerHealthController playerHealthController;

    private void Awake()
    {
        playerHealthController = player.GetComponent<PlayerHealthController>();
    }

    // Update is called once per frame
    void Update()
    {
        UIHealthBar.fillAmount = playerHealthController.playerHealth()/ playerHealthController.playerMaxHealth(); 
    }
}
