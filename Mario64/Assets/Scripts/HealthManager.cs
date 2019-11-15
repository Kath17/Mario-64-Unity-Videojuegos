using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour {

    public static HealthManager instance;

    public int currentHealth, maxHealth;

    public float invicibleLength = 2f;
    private float invincCounter;

    public Text healthText;



    private void Awake()
    {
        instance = this;
    }

	// Use this for initialization
	void Start () {
        ResetHealth();
	}
	
	// Update is called once per frame
	void Update () {

		if(invincCounter >0)
        {
            //Debug.Log("Entra al update");
            invincCounter -= Time.deltaTime;
                        
            for (int i = 0; i < playerController.instance.playerPieces.Length; i++)
            {
                if(Mathf.Floor(invincCounter * 5f) % 2 == 0)
                {
                    playerController.instance.playerPieces[i].SetActive(true);
                }
                else
                {
                    playerController.instance.playerPieces[i].SetActive(false);
                }

                if(invincCounter <= 0)
                {
                    playerController.instance.playerPieces[i].SetActive(true);
                }
            }
            
        }
	}

    public void Hurt()
    {
        //Debug.Log("Entro a funcion Hurt");

        if (invincCounter <=0)
        {
            currentHealth--;

            if (currentHealth <= 0)
            {
                //Debug.Log("Salud menor a 0");
                currentHealth = 0;
                GameManager.instance.Respawn();
            }
            else
            {
                //Debug.Log("Salud mayor a 0");
                playerController.instance.Knockback();
                invincCounter = invicibleLength;

                //playerController.instance.playerModel.SetActive(false);
                
                for (int i=0; i<playerController.instance.playerPieces.Length;i++)
                {
                    playerController.instance.playerPieces[i].SetActive(false);
                }
            }

            UpdateUI();
        }
        
    }

    public void HurtByBoss()
    {
        //Debug.Log("Entro a funcion Hurt");

        if (invincCounter <= 0)
        {
            currentHealth = currentHealth - 3;

            if (currentHealth <= 0)
            {
                //Debug.Log("Salud menor a 0");
                currentHealth = 0;
                GameManager.instance.Respawn();
            }
            else
            {
                //Debug.Log("Salud mayor a 0");
                playerController.instance.Knockback();
                invincCounter = invicibleLength;

                //playerController.instance.playerModel.SetActive(false);

                for (int i = 0; i < playerController.instance.playerPieces.Length; i++)
                {
                    playerController.instance.playerPieces[i].SetActive(false);
                }
            }

            UpdateUI();
        }

    }

    public void ResetHealth()
    {
        currentHealth = maxHealth;
        UpdateUI();
    }

    public void AddHealth(int amountToHeal)
    {
        currentHealth += amountToHeal;
        if(currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }

        UpdateUI();
    }

    public void UpdateUI()
    {
        Debug.Log("Cambiar texto de salud");
        healthText.text = "Salud: "+currentHealth.ToString();
    }
}
