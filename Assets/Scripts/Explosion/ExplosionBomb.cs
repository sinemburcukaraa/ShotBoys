using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static ToonyColorsPro.ShaderGenerator.Enums;

public class ExplosionBomb : MonoBehaviour
{
    //public GameObject explosionEffect;
    public float radius = 5f;
    public float force = 700;
    public BombFragment bombFragment;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            other.gameObject.SetActive(false);
            Explode();
        }
    }

    public void Explode()
    {
        bombFragment.Fragment();

        //Instantiate(explosionEffect, transform.position, transform.rotation);
        Collider[] colliders = Physics.OverlapSphere(transform.position, radius);

        foreach (Collider nearbyObject in colliders)
        {
            Rigidbody rb = nearbyObject.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.AddExplosionForce(force, transform.position, radius);
            }

        }
        //this.gameObject.SetActive(false);
    }
}