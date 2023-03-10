using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DevouringSwarm : Power
{
    public static event Action<float> OnDevouringSwarm;

    void Start()
    {
        Destroy(gameObject, timerKill);
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other);
        if (other.CompareTag("Enemy"))
        {
            other.GetComponent<EnemyHealthController>().SubscribeOnDevouringSwarm();
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