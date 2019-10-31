using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IAPasive : MonoBehaviour {

    public GameObject Target;

    [Header("Ajustes")]
    public int time;
    public float speed;
    float y;
    bool giroTime;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {

        Debug.Log("Entro a update");
        time += 1;
        Target.transform.Translate(Target.transform.forward * speed * Time.fixedDeltaTime);
        Target.transform.Rotate(new Vector3(0, y, 0));

        if(time >= Random.Range(100,2500))
        {
            Girar();
            time = 0;
            giroTime = true;
        }

        if(giroTime == true)
        {
            if (time >= Random.Range(10, 50)) {
                y = 0;
                giroTime = false;
            }
        }
	}

    public void Girar()
    {
        y = Random.Range(-3, 3);
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Terrain")
        {
            Girar();
        }
    }
}
