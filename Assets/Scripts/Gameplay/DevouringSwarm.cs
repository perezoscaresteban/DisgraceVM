using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DevouringSwarm : Power
{
    public static event Action<float> OnDevouringSwarm;

    void Update()
    {
        Destroy(gameObject, timerKill);
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other);
        if (other.tag == "Enemy")
        {
            other.GetComponent<EnemyHealthController>().SubscribeOnDevouringSwarm();
            //var enemy = other.GetComponent<EnemyHealthController>();
            //other.GetComponent<EnemyHealthController>().TakeDamage(damage * Time.deltaTime);
            other.GetComponent<EnemyController>().Stun(timerKill);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        OnDevouringSwarm?.Invoke(damage * Time.deltaTime);
    }

    new public bool coorectTag(string tag)
    {
        return tag == "Ground";
    }

    public void Upgrade()
    {
        damage *= 1.2f;
    }
}