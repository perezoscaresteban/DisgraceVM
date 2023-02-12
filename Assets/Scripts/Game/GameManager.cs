using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public bool dontDestroyOnLoad;
    [SerializeField] PlayerHealthController playerHealthController;
    [SerializeField] GameUI gameUI;

    public float coins;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;

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

    void addCoins(float c)
    {
        coins += c;
    }


}
