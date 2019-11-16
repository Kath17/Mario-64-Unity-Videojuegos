using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ignoring raycast on layer
public class Prueba_RayCast : MonoBehaviour {

    public GameObject Target;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //OneRay();
        //TwoRays();
        ThreeRays();
	}

    void OneRay()
    {
        // El vector direccional a nuestro objetivo
        Vector3 dir = (Target.transform.position - transform.position).normalized;
        RaycastHit hit;
        int rayDistance = 6;

        if (Physics.Raycast(transform.position, transform.forward, out hit, rayDistance))
        {
            Debug.DrawLine(transform.position, hit.point, Color.red);
            dir += hit.normal * 20;
        }
        else
        {
            Debug.DrawRay(transform.position, transform.forward * rayDistance, Color.yellow);
        }

        Quaternion rot = Quaternion.LookRotation(dir);
        transform.rotation = Quaternion.Slerp(transform.rotation, rot, Time.deltaTime);
        transform.position += transform.forward * 5 * Time.deltaTime;
    }
    void TwoRays()
    {
        // El vector direccional a nuestro objetivo
        Vector3 dir = (Target.transform.position - transform.position).normalized;
        RaycastHit hit;
        int rayDistance = 6;

        //Con dos rayos
        Vector3 leftRayoPos = transform.position - (transform.right*1.2f);
        Vector3 rightRayoPos = transform.position + (transform.right*1.2f);

        if (Physics.Raycast(leftRayoPos, transform.forward, out hit, rayDistance))
        {
            Debug.DrawLine(leftRayoPos, hit.point, Color.red);
            dir += hit.normal * 20;
        }
        else if (Physics.Raycast(rightRayoPos, transform.forward, out hit, rayDistance))
        {
            Debug.DrawLine(rightRayoPos, hit.point, Color.red);
            dir += hit.normal * 20;
        }
        else
        {
            Debug.DrawRay(leftRayoPos, transform.forward * rayDistance, Color.yellow);
            Debug.DrawRay(rightRayoPos, transform.forward * rayDistance, Color.yellow);
        }

        Quaternion rot = Quaternion.LookRotation(dir);
        transform.rotation = Quaternion.Slerp(transform.rotation, rot, Time.deltaTime);
        transform.position += transform.forward * 6 * Time.deltaTime;
    }

    void ThreeRays()
    {
        float frontSensorAngle = 30;

        RaycastHit hit;
        Vector3 sensorStartPos = transform.position;
        Vector3 dir = (Target.transform.position - transform.position).normalized;

        int rayDistance = 8;
        int rayDistance_2 = 5;
        Quaternion rot;

        //Con tres rayos
        if (Physics.Raycast(sensorStartPos, transform.forward, out hit, rayDistance))
        {
            Debug.DrawLine(sensorStartPos, hit.point, Color.red);
            dir += hit.normal * 20;

        }
        else if (Physics.Raycast(sensorStartPos, Quaternion.AngleAxis(frontSensorAngle, transform.up) * transform.forward, out hit, rayDistance_2))
        {
            Debug.DrawLine(sensorStartPos, hit.point, Color.red);
            dir += hit.normal * 20;
        }
        else if (Physics.Raycast(sensorStartPos, Quaternion.AngleAxis(-frontSensorAngle, transform.up) * transform.forward, out hit, rayDistance_2))
        {
            Debug.DrawLine(sensorStartPos, hit.point, Color.red);
            dir += hit.normal * 20;
        }
        else
        {
            Debug.DrawRay(transform.position, Quaternion.AngleAxis(frontSensorAngle, transform.up) *  (transform.forward) * rayDistance_2, Color.yellow);
            Debug.DrawRay(transform.position, transform.forward * rayDistance, Color.yellow);
            Debug.DrawRay(transform.position, Quaternion.AngleAxis(-frontSensorAngle, transform.up) * (transform.forward) * rayDistance_2, Color.yellow);
        }
        rot = Quaternion.LookRotation(dir);
        transform.rotation = Quaternion.Slerp(transform.rotation, rot, Time.deltaTime);
        transform.position += transform.forward * 4 * Time.deltaTime;
    }
}
