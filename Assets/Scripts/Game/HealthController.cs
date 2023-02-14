using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthController : MonoBehaviour
{
    public float maxHealth;
    public float health;
    //[SerializeField] Animator animator;
    //Sound

    void Awake()
    {
        health = maxHealth;
    }

    public void TakeDamage(float damage) 
    {
        //Play Sound Effect


        health -= damage;
        if (health < 0)
        { 
            //Animation.SetBool("Dead",True)
            //Show GAME OVER screen
        }
    }

    void Heal(float amount)
    {
        //Play Sound Effect

        health += amount;
        if (health + amount > maxHealth)
        {
            health = maxHealth;
        }
    }
}
