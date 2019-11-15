using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIenemy : MonoBehaviour {

    public GameObject Target;
    public NavMeshAgent agent;

    public float distance;
    public Vida vida_script;

	// Update is called once per frame
	void Update () {
		if(Vector3.Distance(Target.transform.position, transform.position) < distance)
        {
            agent.SetDestination(Target.transform.position);
            agent.speed = 7;
        }
        else
        {
            agent.speed = 0;
        }

        if(Vector3.Distance(Target.transform.position, transform.position) <= 4)
        {
            vida_script.vida_int = vida_script.vida_int - 5;
        }
	}
}
