using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{

    public Rigidbody bulletPrefabs;
    public Transform shootPoint;
    public LayerMask layer;

    public GameObject personaje;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //yield return new WaitForSeconds(15f);
        LaunchProjectile();
    }

    void LaunchProjectile()
    {
        Vector3 V0 = CalculateVelocity(personaje.transform.position, shootPoint.position, 1f);

        transform.rotation = Quaternion.LookRotation(V0);

        //if (Input.GetMouseButtonDown(0))
        //{
        //yield return new WaitForSeconds(1f);
        int r = Random.Range(1, 3000);
        if (r < 10)
        {
            //yield return new WaitForSeconds(1f);
            Rigidbody obj = Instantiate(bulletPrefabs, shootPoint.position, Quaternion.identity);
            obj.velocity = V0;
        }

        //}
    }

    Vector3 CalculateVelocity(Vector3 target, Vector3 origin, float time)
    {
        //define the distance x and y first
        Vector3 distance = target - origin;
        Vector3 distanceXZ = distance;
        distanceXZ.y = 0f;

        //create a float - represent our distance
        float Sy = distance.y;
        float Sxz = distanceXZ.magnitude;

        float Vxz = Sxz / time;
        float Vy = Sy / time + 0.5f * Mathf.Abs(Physics.gravity.y) * time;

        Vector3 result = distanceXZ.normalized;
        result *= Vxz;
        result.y = Vy;

        return result;
    }
}
