using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth1 : MonoBehaviour
{
    public int maxHealth;
    private int currentHealth;

    public GameObject deathEffect, itemToDrop;

    // Use this for initialization
    void Start()
    {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void TakeDamage()
    {
        Debug.Log("ENTRA A HACER DANO");
        currentHealth--;
        playerController.instance.Bounce();

        if (currentHealth <= 0)
        {
            Destroy(gameObject);
            Instantiate(deathEffect, transform.position+new Vector3(0f,2.0f,0f), transform.rotation);
            Instantiate(itemToDrop, transform.position + new Vector3(0f, 1.8f, 0f), transform.rotation);
            //playerController.instance.Bounce();
        }
    }

    public void TakeDamageBlock()
    {
        Debug.Log("ENTRA A DESTRUIR BLOQUE");
        currentHealth--;

        if (currentHealth <= 0)
        {
            Destroy(gameObject);
            Instantiate(deathEffect, transform.position + new Vector3(0f, 2.0f, 0f), transform.rotation);
            Instantiate(itemToDrop, transform.position - new Vector3(0f, 5.7f, 0f), transform.rotation);
            //playerController.instance.Bounce();
        }
    }
}
