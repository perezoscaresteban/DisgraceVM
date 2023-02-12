using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEditor.Rendering;
using UnityEngine;




public enum EnemyState
{
    Idle,
    Patrol,
    Pursuit,
    RunAway,
    Seeker,
    Attack
}

public enum EnemyRotation { 
    Direct,
    Lerp
}


public class EnemyController : MonoBehaviour
{
    [SerializeField] private Transform objetive;
    [SerializeField] LayerMask playerMask   ;
    [SerializeField] private Transform toPatrol;
    [SerializeField] private float timeToPatrol;
    [SerializeField] private EnemyState currentState;
    [SerializeField] private float speed;
    [SerializeField] private float pursuitDistance;
    [SerializeField] private float rotationSpeed;
    [SerializeField] private float rangeMeleeAttack;
    [SerializeField] private Animator enemyAnimator;
    [SerializeField] private float damage;
    [SerializeField] GameObject player;
    private HealthController playerHealthController;

    private float originalSpeed;

    public void SetCurrentState()
    {
        switch (currentState)
        {
            case EnemyState.Idle:
                ExecuteIdle();
                break;
            case EnemyState.Patrol:
                ExecutePatrol();
                break;
            case EnemyState.Pursuit:
                ExecutePursuit();
                break;
            case EnemyState.RunAway:
                ExecuteRunAway();
                break;
            case EnemyState.Seeker:
                ExecuteSeeker();
                break;
            case EnemyState.Attack:
                ExecuteAttack();
                break;
            default:
                Debug.LogError("Current state is invalid");
                break;
        }
    }

    private void ExecuteIdle()
    {
        enemyAnimator.SetFloat("Speed", 0);

    }


    private void ExecutePatrol()
    {

        var vectorToPatrol = toPatrol.position - transform.position;
        var distance = vectorToPatrol.magnitude;
        if (distance < pursuitDistance)
        {
            Quaternion newRotation = Quaternion.LookRotation(objetive.position - transform.position);
            transform.rotation = newRotation;
            transform.position += vectorToPatrol.normalized * (speed * Time.deltaTime);

        }
        else
        {
            currentState = EnemyState.Idle; 
        }

    }

    private void ExecutePursuit()
    {
        var vectorToObjetive = objetive.position - transform.position;
        var distance = vectorToObjetive.magnitude;
        if (AbleToAttack())
        {
            ExecuteAttack();
        }
        else if (distance <= pursuitDistance && distance >= rangeMeleeAttack)
        {
            speed = originalSpeed;
            Quaternion newRotation = Quaternion.LookRotation(objetive.position - transform.position);
            transform.rotation = newRotation;
            transform.position += vectorToObjetive.normalized * (speed * Time.deltaTime);
        }
        else if (distance > pursuitDistance)
        {
            ExecuteIdle();
        }
    }

    private void ExecuteRunAway()
    {
        speed = originalSpeed;
        var vectorToObjetive = transform.position - objetive.position;
        var distance = vectorToObjetive.magnitude;
        if (distance < pursuitDistance)
        {
            Quaternion newRotation = Quaternion.LookRotation(objetive.position - transform.position);
            transform.rotation = newRotation;
            transform.position += vectorToObjetive.normalized * (speed * Time.deltaTime);
        }

    }

    private void ExecuteSeeker()
    {
        Quaternion newRotation = Quaternion.LookRotation(objetive.position - transform.position);
        transform.rotation = Quaternion.Lerp(transform.rotation,newRotation, Time.deltaTime * rotationSpeed);
    }

    private void ExecuteAttack()
    {
        speed = 0;
        enemyAnimator.SetBool("Attack", true);
        if (!AbleToAttack())
        {
            speed = originalSpeed;
        }
        playerHealthController.TakeDamage(damage * Time.deltaTime);

    }

    private void Awake()
    {
        playerHealthController = player.GetComponent<HealthController>();
    }

    private void Update()
    {
        enemyAnimator.SetFloat("Speed", speed);
        enemyAnimator.SetBool("Attack", AbleToAttack());
        SetCurrentState();
    }

    private void Start()
    {
        originalSpeed = speed;
    }

    private bool AbleToAttack()
    {
        return Physics.CheckSphere(transform.position, rangeMeleeAttack, playerMask);
    }

}
