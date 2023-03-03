using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthController : MonoBehaviour
{
    public float maxHealth;
    public float health;
    //[SerializeField] Animator animator;
    //Sound
    private EnemyController enemyController;
    [SerializeField] protected EnemyData enemyData;

    void Awake()
    {
        health = enemyData.maxHealth;
        enemyController = GetComponent<EnemyController>();
    }

    public void TakeDamage(float damage) 
    {
        //Play Sound Effect

        health -= damage;
        if (health <= 0)
        {
            enemyController.Die();  
            //Animation.SetBool("Dead",True)
            //Show GAME OVER screen
        }
        else
        {
            enemyController.Pursuit();
        }

    }

    public void Heal(float amount)
    {
        //Play Sound Effect

        health += amount;
        if (health + amount > maxHealth)
        {
            health = maxHealth;
        }
    }
}
