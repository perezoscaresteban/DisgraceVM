using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthController : MonoBehaviour
{
    [SerializeField] protected float maxHealth;
    [SerializeField] public float health;
    [SerializeField] Animator animator;
    //Sound
    private EnemyController enemyController;
    [SerializeField] protected EnemyData enemyData;

    public event Action OnDeath;

    void Awake()
    {
        maxHealth = enemyData.maxHealth;
        health = enemyData.maxHealth;
        enemyController = GetComponent<EnemyController>();
    }


    public void TakeDamage(float damage) 
    {
        //Play Sound Effect

        Debug.Log("Take Damage "+damage);
        if (health <= damage)
        {
            health = 0;
            OnDeath?.Invoke();
            //Animation.SetBool("Dead",True)
            //Show GAME OVER screen
        }
        else
        {
            health -= damage;
            enemyController.enemyAnimator.SetBool("Hitted", true);
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

    public void SubscribeOnDevouringSwarm()
    {
        DevouringSwarm.OnDevouringSwarm += TakeDamage;
    }
}
