using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public float damage;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other);
        if (other.tag == "Enemy")
        {
            other.GetComponent<EnemyHealthController>().TakeDamage(damage);
        }
    }
}
