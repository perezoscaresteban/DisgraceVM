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
    Stunned,
    Died
}

public enum EnemyRotation { 
    Direct,
    Lerp
}


public class EnemyController : MonoBehaviour
{
    [SerializeField] EnemyHealthController healthController;
    [SerializeField] private Transform objective;
    [SerializeField] protected EnemyData enemyData;
    private float countToPatrol;
    private Patrol toPatrol;
    private Transform pointToPatrol;
    [SerializeField] private EnemyState currentState;
    private float speed;
    [SerializeField] Transform rayCastPoint; 
    private float timerStunned;
    private Ragdoll ragdoll;

    public Animator enemyAnimator;
    public GameObject player;
    public PlayerHealthController playerHealthController;
    private float timerA;

    private void Awake()
    {
        playerHealthController = player.GetComponent<PlayerHealthController>();
        toPatrol = gameObject.GetComponent<Patrol>();
        healthController = gameObject.GetComponent<EnemyHealthController>();
        pointToPatrol = toPatrol.NextPoint();
        ragdoll = gameObject.GetComponent<Ragdoll>();
        countToPatrol = 2;
    }

    void Start () 
    {
        healthController.OnDeath += Die;
    }

    private void Update()
    {
        enemyAnimator.SetFloat("Speed", speed);
        enemyAnimator.SetBool("Attack", AbleToAttack());
        SetCurrentState();
        Debug.Log(currentState);

   }

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
            case EnemyState.Died:
                ExecuteDied();
                break;

            default:
                Debug.LogError("Current state is invalid");
                break;
        }
    }

    private void ExecuteIdle()
    {
        speed = 0;
        countToPatrol -= Time.deltaTime;
        Ray ray = new Ray(rayCastPoint.transform.position, rayCastPoint.transform.forward * enemyData.lineVision);
        RaycastHit hitInfo;
        if (Physics.Raycast(ray, out hitInfo, enemyData.lineVision))
        {
            Debug.DrawRay(ray.origin, ray.direction * enemyData.lineVision, Color.yellow);
            if (hitInfo.collider.tag == "Player")
            {
                currentState = EnemyState.Pursuit;
            }
        } 
        else if (countToPatrol < 0) 
        {
            currentState = EnemyState.Patrol;
        }
    }

    private void ExecutePatrol()
    {
        speed = enemyData.walkSpeed;
        countToPatrol = enemyData.timeToPatrol;
        var vectorToObjective = pointToPatrol.position - transform.position;
        var distance = vectorToObjective;

        Ray ray = new Ray(rayCastPoint.transform.position, rayCastPoint.transform.forward * enemyData.lineVision);
        RaycastHit hitInfo;
        if (Physics.Raycast(ray, out hitInfo, enemyData.lineVision))
        {
            Debug.DrawRay(ray.origin, ray.direction * enemyData.lineVision, Color.yellow);
            if (hitInfo.collider.tag == "Player")
            {
                currentState = EnemyState.Pursuit;
            }
        }
        Debug.DrawRay(ray.origin, vectorToObjective, Color.blue);
        if (Vector2.Distance(pointToPatrol.position, transform.position) < 0.5)

        {
            pointToPatrol = toPatrol.NextPoint();
        }
            Quaternion newRotation = Quaternion.LookRotation(pointToPatrol.position - transform.position);
            transform.rotation = newRotation;
            transform.position += vectorToObjective.normalized * (enemyData.walkSpeed * Time.deltaTime);
    }

    private void ExecutePursuit()
    {

        var vectorToObjective = objective.position - transform.position;
        var distance = vectorToObjective.magnitude;
        if (AbleToAttack())
        {
            currentState = EnemyState.Attack;
        }
        else if (distance <= enemyData.pursuitDistance && distance >= enemyData.rangeMeleeAttack)
        {
            speed = enemyData.pursuitSpeed;
            Quaternion newRotation = Quaternion.LookRotation(objective.position - transform.position);
            transform.rotation = newRotation;
            transform.position += vectorToObjective.normalized * (enemyData.pursuitSpeed * Time.deltaTime);
        }
        else if (distance > enemyData.pursuitDistance)
        {
            currentState = EnemyState.Idle;
        }

    }

    private void ExecuteStunned()
    {
        speed = 0;
        timerStunned -= Time.deltaTime;
        if (timerStunned <= 0) 
        {

            enemyAnimator.SetBool("Stunned", false);
            currentState = EnemyState.Pursuit;
        }
        //ANIMATOR
    }

    private void ExecuteAttack()
    {
        speed = 0;
        enemyAnimator.SetBool("Attack", true);
        if (!AbleToAttack())
        {
            speed = enemyData.pursuitSpeed;
            currentState = EnemyState.Pursuit;
        }
        //playerHealthController.TakeDamage(enemyData.damage * Time.deltaTime);
    }

    private void ExecuteDied() 
    {
        ragdoll.Activate();
    }

    public bool AbleToAttack()
    {
        return Physics.CheckSphere(transform.position, enemyData.rangeMeleeAttack, enemyData.playerMask);
    }
    public void Stun(float amount)
    {
        currentState = EnemyState.Stunned;
        enemyAnimator.SetBool("Stunned", true);

        timerStunned = amount;
    }

    public void Die() 
    {
        currentState = EnemyState.Died;
        gameObject.tag = "Corpse";
    }

    public void Pursuit() 
    {
        currentState = EnemyState.Pursuit;
    }

    public LayerMask PlayerMask() 
    {
        return enemyData.playerMask;
    }
}
