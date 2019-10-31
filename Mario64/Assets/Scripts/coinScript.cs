using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coinScript : MonoBehaviour {

    public int value;
    public GameObject pickupEffect;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    // Cuando otro collider entre en esta area
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            FindObjectOfType<GameManager>().AddCoin(value);
            Instantiate(pickupEffect, transform.position, transform.rotation);
            Destroy(this.gameObject);
            //Debug.Log("Moneda conseguida");
        }
    }

}
