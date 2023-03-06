using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerHealthController : MonoBehaviour
{
    public float maxHealth;
    public float health;
    //[SerializeField] Animator animator;
    //Sound

    public static event Action<float> OnHealthChange;
    public static event Action<float> OnMaxHealthChange;

    void Start()
    {
        health = maxHealth;
        OnHealthChange?.Invoke(health);
        OnMaxHealthChange?.Invoke(maxHealth);
    }

    public void TakeDamage(float damage) 
    {
        //Play Sound Effect
        health -= damage;
        if (health - damage < 0)
        { 
            //Animation.SetBool("Dead",True)
            //Show GAME OVER screen
        }
        OnHealthChange?.Invoke(health);
    }

    void Heal(float amount)
    {
        //Play Sound Effect
        health += amount;
        if (health + amount > maxHealth)
        {
            health = maxHealth;
        }
        OnHealthChange?.Invoke(health);
    }
}