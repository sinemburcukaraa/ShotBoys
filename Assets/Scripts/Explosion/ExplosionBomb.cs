using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionBomb : MonoBehaviour
{
    //public GameObject explosionEffect;
    public float radius = 5f;
    public float force = 700;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bullet"))
        {
            other.gameObject.SetActive(false);

            Explode();
        }
    }
    public void Explode()
    {
        //Instantiate(explosionEffect, transform.position, transform.rotation);
        Collider[] colliders = Physics.OverlapSphere(transform.position, radius);

        foreach (Collider nearbyObject in colliders)
        {
            Rigidbody rb = nearbyObject.GetComponent<Rigidbody>();
            if (rb!=null)
            {
                rb.AddExplosionForce(force,transform.position,radius);
            }
        }


        this.gameObject.SetActive(false);
    }
}
