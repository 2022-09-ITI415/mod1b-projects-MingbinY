using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public enum EnemyState
{
    Idle,
    Patrol,
    ChasePlayer
}
public class EnemyController : MonoBehaviour
{
    public GameObject playerObj;

    NavMeshAgent agent;
    public EnemyState initState = EnemyState.Idle;
    EnemyState currentState;

    public Transform[] patrolPoints;
    int patrolPointIndex = 0;

    public float viewDist = 10;
    public float attackDist = 5;
    public float moveSpeed = 3.5f;

    public bool isAttacking;

    public float attackCooldown = 3f;

    public virtual void Awake()
    {
        playerObj = FindObjectOfType<PlayerController>().gameObject;
        agent = GetComponent<NavMeshAgent>();
        currentState = initState;
        patrolPointIndex = 0;
        agent.updateRotation = true;
    }

    private void Update()
    {

        switch (currentState)
        {
            case EnemyState.Idle:
                IdleUpdate();
                break;
            case EnemyState.Patrol:
                PatrolUpdate();
                break;
            case EnemyState.ChasePlayer:
                ChaseUpdate();
                break;
        }
            
    }

    void IdleUpdate()
    {
        // do nothing
        if (PlayerInsight())
        {
            currentState = EnemyState.ChasePlayer;
            return;
        }
    }

    void PatrolUpdate()
    {
        if (PlayerInsight())
        {
            currentState = EnemyState.ChasePlayer;
            return;
        }
        agent.stoppingDistance = 0;
        agent.SetDestination(patrolPoints[patrolPointIndex].position);

        if (!agent.hasPath)
        {
            if (patrolPointIndex < patrolPoints.Length - 1)
            {
                patrolPointIndex++;
            }
            else
            {
                patrolPointIndex = 0;
            }
        }
    }

    void ChaseUpdate()
    {
        agent.stoppingDistance = attackDist;
        agent.updateRotation = true;

        LookAtPlayer();
        if (!isAttacking && Vector3.Distance(transform.position, playerObj.transform.position) > attackDist)
        {
            // if player is out of attack range and the enemy is not attacking the enemy can move
            agent.SetDestination(playerObj.transform.position);
            return;
        }

        

        if (Vector3.Distance(transform.position, playerObj.transform.position) <= attackDist)
        {
            if (PlayerInsight())
            {
                LookAtPlayer();
                // if player is in attack range
                if (!isAttacking)
                {
                    isAttacking = true;
                    Attack();
                }
            }
        }else if (!isAttacking)
        {
            agent.SetDestination(playerObj.transform.position);
        }
    }

    void LookAtPlayer()
    {
        Vector3 targetPos = playerObj.transform.position;
        targetPos.y = transform.position.y;

        transform.LookAt(targetPos);
    }

    bool PlayerInsight()
    {
        Collider[] cols = Physics.OverlapSphere(transform.position, viewDist);

        foreach (Collider col in cols)
        {
            if (col.GetComponent<PlayerController>())
            {
                RaycastHit hit;
                Vector3 dir = col.transform.position - transform.position;
                if (Physics.Raycast(transform.position, dir, out hit))
                {
                    if (hit.collider == col)
                    {
                        return true;
                    }
                }
            }
        }
        return false;
    }

    public virtual void Attack()
    {

    }
}
