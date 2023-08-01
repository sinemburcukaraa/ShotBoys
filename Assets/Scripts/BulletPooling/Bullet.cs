using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.XR;
using static ToonyColorsPro.ShaderGenerator.Enums;

public class Bullet : MonoBehaviour
{
    public int speed = 30;
    Rigidbody rb;
    public AudioSource shotingSound, explosionSound;
    public GameObject fireExplosionEffect;
    public BulletPooling bulletPooling;
    public Transform sourcePosition;
  
    private void Start()
    {
        shotingSound = GetComponent<AudioSource>();
        playShotingSound();
    }

    void OnEnable()
    {
        rb = GetComponent<Rigidbody>();
        Fire();
    }

    //private void OnDisable()
    //{
    //    transform.position = PoolingManager.Instance.BulletFirstPos.position;
    //}
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy") && !other.GetComponent<EnemyMovement>().used)
        {
            other.GetComponent<EnemyMovement>().used = true;
            other.gameObject.GetComponent<Ragdoll>().RagdollActive(true);
            PlayExplosionSound();

            AfterTheShot();

        }
        else if (other.CompareTag("Obstacle"))
        {
            PlayExplosionSound();
            fireExplosionEffect.SetActive(true);

            AfterTheShot();

        }
    }

    public void AfterTheShot()
    {
        rb.velocity = Vector3.zero;
        Invoke("Deactive", 3);

    }
    public void Deactive()
    {
        this.gameObject.SetActive(false);
    }
    public void playShotingSound()
    {
        shotingSound.Play();
    }
    public void PlayExplosionSound()
    {
        explosionSound.Play();
    }
    public void Fire()
    {
        transform.position = sourcePosition.position;
        rb.velocity = sourcePosition.forward * speed;
        Invoke("Invisible", 2f);

    }

    public void Invisible()
    {
        rb.velocity = Vector3.zero;
        GameManager.instance.GameOver();
        this.gameObject.SetActive(false);

    }

}

