using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DevouringSwarm : Power
{
    private List<GameObject> objectives;
    void Awake()
    {

    }
    void Update()
    {
        Destroy(gameObject, timerKill);
    }
    private void OnColissionStay(Collider other)
    {
        if (other.TryGetComponent<HealthController>(out var healthController))
        {
            healthController.TakeDamage(damage);
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Enemy")
        {
            var enemy = other.GetComponent<HealthController>();
            other.GetComponent<HealthController>().TakeDamage(damage * Time.deltaTime);
            other.GetComponent<EnemyController>().Stun(0.1f);
        }
    }

    new public bool coorectTag(string tag)
    {
        return tag == "Ground";
    }
}