using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class bobombController : MonoBehaviour {

    public Transform[] patrolPoints;
    public int currentPatrolPoint;

    public NavMeshAgent agent;

    public Animator anim;

    public enum AIState
    {
        isIdle, isPatrolling, isChasing, isAttacking
    };

    public AIState currentState;
    public float waitAtPoint = 2f;
    private float waitCounter;

    public float chaseRange;

    public float attackRange = 1f;
    public float timeBetweenAttacks = 2f;
    private float attackCounter;

	// Use this for initialization
	void Start () {
        waitCounter = waitAtPoint;
	}
	
	// Update is called once per frame
	void Update ()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, playerController.instance.transform.position);
        switch (currentState)
        {
            case AIState.isIdle:
                anim.SetBool("isMoving", false);

                if(waitCounter > 0)
                {
                    waitCounter -= Time.deltaTime;
                }
                else
                {
                    currentState = AIState.isPatrolling;
                    agent.SetDestination(patrolPoints[currentPatrolPoint].position);
                }
                if(distanceToPlayer <= chaseRange)
                {
                    currentState = AIState.isChasing;
                    anim.SetBool("isMoving", true);
                }

                break;

            case AIState.isPatrolling:
                //agent.SetDestination(patrolPoints[currentPatrolPoint].position);

                if (agent.remainingDistance <= .1f)
                {
                    currentPatrolPoint++;
                    if (currentPatrolPoint >= patrolPoints.Length)
                    {
                        currentPatrolPoint = 0;
                    }

                    currentState = AIState.isIdle;
                    waitCounter = waitAtPoint;
                    //agent.SetDestination(patrolPoints[currentPatrolPoint].position);
                }
                if (distanceToPlayer <= chaseRange)
                {
                    currentState = AIState.isChasing;
                    //anim.SetBool("isMoving", true);
                }

                anim.SetBool("isMoving", true);
                break;

            case AIState.isChasing:
                agent.SetDestination(playerController.instance.transform.position);

                if(distanceToPlayer <= attackRange)
                {
                    currentState = AIState.isAttacking;
                    anim.SetTrigger("Attack");
                    anim.SetBool("isMoving", false);

                    agent.velocity = Vector3.zero;
                    agent.isStopped = true;

                    attackCounter = timeBetweenAttacks;

                }
                else if(distanceToPlayer >= chaseRange)
                {
                    anim.SetBool("isMoving", false);
                    currentState = AIState.isPatrolling;
                }
                break;

            case AIState.isAttacking:

                transform.LookAt(playerController.instance.transform, Vector3.up);
                transform.rotation = Quaternion.Euler(0, transform.rotation.eulerAngles.y, 0f);

                attackCounter -= Time.deltaTime;
                if(attackCounter <= 0)
                {
                    if(distanceToPlayer < attackRange)
                    {
                        anim.SetTrigger("Attack");
                        attackCounter = timeBetweenAttacks;
                    }
                    else
                    {
                        currentState = AIState.isIdle;
                        waitCounter = waitAtPoint;

                        agent.isStopped = false;
                    }
                }
                break;
        }
	}
}
