using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthController : MonoBehaviour
{
    [SerializeField] float maxHealth;
    [SerializeField] float currentHealth;
    //[SerializeField] Animator animator;
    //Sound

    void Awake()
    {
        currentHealth = maxHealth;
        Debug.Log(currentHealth);
    }

    void TakeDamage(float damage) 
    {
        //Play Sound Effect

        currentHealth -= damage;
        if (currentHealth < 0)
        { 
            //Animation.SetBool("Dead",True)
            //Show GAME OVER screen
        }
    }

    void Heal(float amount)
    {
        //Play Sound Effect

        currentHealth += amount;
        if (currentHealth + amount > maxHealth)
        {
            currentHealth = maxHealth;
        }
    }

    public float playerHealth() 
    {
        return currentHealth;
    }

    public float playerMaxHealth()
    {
        return maxHealth;
    }
}
