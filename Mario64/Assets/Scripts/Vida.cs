using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Vida : MonoBehaviour {

    public Text vida;
    public int vida_int = 100;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        vida.text = "Vida: "+ (vida_int.ToString());
        if(vida_int < 1)
        {
            vida.text = "Murio";
        }
	}
}
