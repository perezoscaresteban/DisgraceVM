using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/Enemy/EnemyData")]
public class EnemyData : ScriptableObject
{
    public float maxHealth;
    public LayerMask playerMask;
    public float lineVision;
    public float rotationSpeed;
    public float rangeMeleeAttack;
    public float walkSpeed;
    public float damage;
    public float pursuitDistance; 
    public float pursuitSpeed;
    public float timeToPatrol;

}
