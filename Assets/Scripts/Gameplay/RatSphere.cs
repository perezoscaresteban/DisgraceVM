using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;



public class RatSphere : MonoBehaviour
{
    [SerializeField] float damage;
    [SerializeField] float timerKill;
    public float timerReload;

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
            Debug.Log(healthController.health);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Enemy")
        {
            var enemy = other.GetComponent<HealthController>();
            other.GetComponent<HealthController>().TakeDamage(damage*Time.deltaTime);
            other.GetComponent<EnemyController>().Stun();
        }
    }
}
