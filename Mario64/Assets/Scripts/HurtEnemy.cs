using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtEnemy : MonoBehaviour {

    //EnemyHealth1 enemyHealth1;
	// Use this for initialization
	void Start () {
		//enemyHealth1 = GetComponent<EnemyHealth1>();
	}
	
    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("ON TRIGGER");
        Debug.Log(other.tag);

        if (other.tag == "Enemy")
        {
            other.GetComponent<EnemyHealth1>().TakeDamage();
            //enemy.GetComponent<EnemyHealth1>().TakeDamage(enemy);
        }
        else if (other.tag == "Block")
        {
            other.GetComponent<EnemyHealth1>().TakeDamageBlock();
        }
    }
}
