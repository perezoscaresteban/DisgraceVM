using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] float value;

    private void Take()
    {
        GameManager.Instance.AddCoins(value);
        Destroy(gameObject);
        //AudioManager.Instance.Sound(coinSFX);
    }


}
