using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class starScript : MonoBehaviour {

    public int value;
    public GameObject pickupEffect;

    //public Text healthText;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    // Cuando otro collider entre en esta area
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Entro al trigger de la estrella");
        if (other.tag == "Player")
        {
            Debug.Log("Detecto de que es Mario");
            //FindObjectOfType<GameManager>().AddCoin(value);
            Instantiate(pickupEffect, transform.position, transform.rotation);
            Destroy(this.gameObject);
            //healthText.text = ("¡GANASTE!");
        }
    }
}
