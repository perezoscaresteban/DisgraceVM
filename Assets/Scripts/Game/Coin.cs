using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public float value;

    public void Take()
    {
        GameManager.Instance.AddCoins(value);
        Destroy(gameObject);
        //AudioManager.Instance.Sound(coinSFX);
    }


}
