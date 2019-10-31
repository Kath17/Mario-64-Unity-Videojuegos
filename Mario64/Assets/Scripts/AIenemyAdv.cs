using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIenemyAdv : MonoBehaviour {

    [Header("Ajustes")]

    public int tiempo;
    public float Speed;
    public Transform PuntoGuarida;
    public NavMeshAgent agent;
    public Animator anim;

    [Header("Estados")]
    public bool Idle;
    public bool Atacar;
    public bool Alerta;
    public int Estado = 1;

    bool Cambio = true;
    bool Tiempodegiro;
    float y;
    
    // Update is called once per frame
	void FixedUpdate () {
        tiempo += 1;

        if(Estado == 1)
        {
            Idle = true;
            Atacar = false;
            Alerta = false;
            agent.enabled = false;
        }
        else if(Estado == 2)
        {
            agent.enabled = true;
            Idle = false;
            Atacar = true;
            Alerta = false;
        }
        else if(Estado == 3)
        {
            agent.enabled = true;
            Idle = false;
            Atacar = false;
            Alerta = true;
        }

        if(Idle == true)
        {
            
            transform.Translate(Vector3.forward * Speed * Time.fixedDeltaTime);
            transform.Rotate(new Vector3(0, y, 0));
            anim.SetBool("Caminar", true);
            anim.SetBool("Correr", false);

            if (tiempo >= Random.Range(100, 2500))
            {
                Girar();
                tiempo = 0;
                Tiempodegiro = true;
            }

            if (Tiempodegiro == true)
            {
                if (tiempo >= Random.Range(10, 30))
                {
                    y = 0;
                    Tiempodegiro = false;
                }
            }
        }
        else if(Atacar == true)
        {
            anim.SetBool("Caminar", false);
            anim.SetBool("Correr", true);

            agent.SetDestination(GameObject.FindGameObjectWithTag("Player").transform.position);
            if(Vector3.Distance(GameObject.FindGameObjectWithTag("Player").transform.position, transform.position)>30)
            {
                Estado = 1;
                Cambio = true;
            }
        }
        else if(Alerta == true)
        {
            anim.SetBool("Caminar", false);
            anim.SetBool("Correr", true);

            agent.SetDestination(PuntoGuarida.position);
            if(Vector3.Distance(PuntoGuarida.position, transform.position) < 4)
            {
                anim.SetBool("Caminar", false);
                anim.SetBool("Correr", false);
                if (tiempo > Random.Range(500, 1000)){
                    Estado = 1;
                }
            }
        }
        
	}

    public void Girar()
    {
        y = Random.Range(-3, 3);
    }

    public void CambiarEstado()
    {
        Estado = Random.Range(2,4);
        if(Estado == 2)
        {
            Cambio = false;
        }
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Player" && Cambio == true)
        {
            CambiarEstado();
        }
    }
}
