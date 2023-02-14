using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEditor.Rendering;
using UnityEditor.Experimental.GraphView;
using UnityEngine;




public enum EnemyState
{
    Idle,
    Patrol,
    Pursuit,
    Attack,
    Stunned
}

public enum EnemyRotation { 
    Direct,
    Lerp
}


public class EnemyController : MonoBehaviour
{
    [SerializeField] private Transform objetive;
    [SerializeField] LayerMask playerMask;
    [SerializeField] private Transform toPatrol;
    [SerializeField] private float timeToPatrol;
    [SerializeField] private EnemyState currentState;
    [SerializeField] private float pursuitSpeed;
    private float speed;
    [SerializeField] private float pursuitDistance;
    [SerializeField] private float rotationSpeed;
    [SerializeField] private float rangeMeleeAttack;
    [SerializeField] private Animator enemyAnimator;
    [SerializeField] private float damage;
    [SerializeField] GameObject player;
    [SerializeField] Transform rayCastPoint;
    private HealthController playerHealthController;
    public bool stunned;

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
            case EnemyState.Attack:
                ExecuteAttack();
                break;
            case EnemyState.Stunned:
                ExecuteStunned();
                break;

            default:
                Debug.LogError("Current state is invalid");
                break;
        }
    }

    private void ExecuteIdle()
    {
        speed = 0;
        Ray ray = new Ray(rayCastPoint.transform.position, rayCastPoint.transform.forward * 10);
        RaycastHit hitInfo;
        if (Physics.Raycast(ray, out hitInfo, 10))
        {
            Debug.DrawRay(ray.origin, ray.direction * 10, Color.yellow);
            if (hitInfo.collider.tag == "Player")
            {
                currentState = EnemyState.Pursuit;
            }
        }
    }


    private void ExecutePatrol()
    {

    }

    private void ExecutePursuit()
    {
        var vectorToObjetive = objetive.position - transform.position;
        var distance = vectorToObjetive.magnitude;
        if (AbleToAttack())
        {
            currentState = EnemyState.Attack;
        }
        else if (distance <= pursuitDistance && distance >= rangeMeleeAttack)
        {
            Debug.Log(speed);
            speed = pursuitSpeed;
            Quaternion newRotation = Quaternion.LookRotation(objetive.position - transform.position);
            transform.rotation = newRotation;
            transform.position += vectorToObjetive.normalized * (pursuitSpeed * Time.deltaTime);
        }
        else if (distance > pursuitDistance)
        {
            currentState = EnemyState.Idle;
        }

    }

    private void ExecuteStunned()
    {
        speed = 0;
        Debug.Log(stunned);
        enemyAnimator.SetBool("Stunned", stunned);
    }

    private void ExecuteAttack()
    {
        speed = 0;
        enemyAnimator.SetBool("Attack", true);
        if (!AbleToAttack())
        {
            speed = pursuitSpeed;
            currentState = EnemyState.Pursuit;
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
    }

    public bool AbleToAttack()
    {
        return Physics.CheckSphere(transform.position, rangeMeleeAttack, playerMask);
    }
    public void Stun()
    {
        stunned = true;
        currentState = EnemyState.Stunned;
    }
}
