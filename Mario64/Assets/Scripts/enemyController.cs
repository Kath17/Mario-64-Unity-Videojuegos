using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class enemyController : MonoBehaviour {

    public GameObject Target;
    public NavMeshAgent agent;

    public float distancia;

	// Update is called once per frame
	void Update () {
		if(Vector3.Distance(Target.transform.position, transform.position) < distancia)
        {
            agent.SetDestination(Target.transform.position);
            agent.speed = 3;
        }
        else
        {
            agent.speed = 0;
        }
	}

    void OnDrawGizmosSelected()
    {
        
    }
}
