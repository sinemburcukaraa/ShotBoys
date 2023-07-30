using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static ToonyColorsPro.ShaderGenerator.Enums;

public class ExplosionBomb : MonoBehaviour
{
    public GameObject explosionEffects;
    public float radius = 5f;
    public float force = 700;
    public BombFragment bombFragment;
    AudioSource explosionSound;
    private void Start()
    {
        explosionSound = GetComponent<AudioSource>();
    }
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
        ExplosionEffectPlay();
        Collider[] colliders = Physics.OverlapSphere(transform.position, radius);

        foreach (Collider nearbyObject in colliders)
        {
            ObjectsInTheAffectedArea(nearbyObject);

            Rigidbody rb = nearbyObject.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.AddExplosionForce(force, transform.position, radius);
            }
        }

        this.gameObject.GetComponent<CapsuleCollider>().enabled = false;
    }
    public void ObjectsInTheAffectedArea(Collider colliders)
    {
        if (colliders.gameObject.tag == "Enemy")
        {
            colliders.GetComponent<Ragdoll>().RagdollActive(true);
        }
    }
    public void ExplosionEffectPlay()
    {
        explosionEffects.SetActive(true);
        explosionSound.Play();
    }


}
