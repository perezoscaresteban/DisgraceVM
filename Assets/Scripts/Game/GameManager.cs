using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public bool dontDestroyOnLoad;

    public HealthController playerHealthController;
    public float coins;

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

    void Start()
    {

    }


    void Update()
    {

    }

    public void AddCoins(float c)
    {
        coins += c;
    }

}
