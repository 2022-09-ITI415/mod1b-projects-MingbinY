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

    private void Awake()
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

        agent.SetDestination(playerObj.transform.position);
    }

    bool PlayerInsight()
    {
        Collider[] cols = Physics.OverlapSphere(transform.position, viewDist);

        foreach (Collider col in cols)
        {
            if (col.GetComponent<PlayerController>())
            {
                return true;
            }
        }
        return false;
    }


}