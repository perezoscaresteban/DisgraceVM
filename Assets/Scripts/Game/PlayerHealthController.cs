using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthController : MonoBehaviour
{
    public float maxHealth;
    public float health;
    private HUD hUD;
    //[SerializeField] Animator animator;
    //Sound

    void Awake()
    {
        hUD = HUD.Instance;
        hUD.UpdateMaxHealth(maxHealth);
        health = maxHealth;
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
        hUD.UpdateHealth(health);
    }

    void Heal(float amount)
    {
        //Play Sound Effect
        health += amount;
        if (health + amount > maxHealth)
        {
            health = maxHealth;
        }
        hUD.UpdateHealth(health);
    }
}
