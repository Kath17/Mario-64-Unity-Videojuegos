using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public static GameManager instance;

    private Vector3 respawnPosition, camSpawnPosition;

    public int currentCoin;
    public Text coinText;

    public GameObject deathEffect;

    private void Awake()
    {
        instance = this;
    }

	// Use this for initialization
	void Start () {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        respawnPosition = playerController.instance.transform.position;
        camSpawnPosition = cameraController.instance.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void AddCoin(int coinToAdd)
    {
        currentCoin += coinToAdd;
        coinText.text = "Monedas: " + currentCoin;
    }

    public void Respawn()
    {
        StartCoroutine(RespawnCo());
    }

    public IEnumerator RespawnCo()
    {
        //Debug.Log("I'm respawing");
        playerController.instance.gameObject.SetActive(false);

        Instantiate(deathEffect, playerController.instance.transform.position + new Vector3(0f,1f,0f), playerController.instance.transform.rotation);

        yield return new WaitForSeconds(1f);

        HealthManager.instance.ResetHealth();

        playerController.instance.transform.position = respawnPosition;
        cameraController.instance.transform.position = camSpawnPosition;

        playerController.instance.gameObject.SetActive(true);
    }
}
