using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] protected CoinData coinData;

    public void Take()
    {
        GameManager.Instance.AddCoins(coinData.value);
        Destroy(gameObject);
        //AudioManager.Instance.Sound(coinSFX);
    }


}
