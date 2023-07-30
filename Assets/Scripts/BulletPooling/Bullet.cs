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

    private void OnDisable()
    {
        transform.position = PoolingManager.Instance.BulletFirstPos.position;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            other.gameObject.GetComponent<Ragdoll>().RagdollActive(true);
            PlayExplosionSound();

            AfterTheShot();

        }
        if (other.CompareTag("Obstacle"))
        {
            PlayExplosionSound();
            AfterTheShot();

        }
    }

    public void AfterTheShot()
    {
        rb.velocity = Vector3.zero;
        //fireExplosionEffect.SetActive(true);
        DOVirtual.DelayedCall(3, () => { this.gameObject.SetActive(false); });
        UIManager.instance.OpengameOverPanel();

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
        transform.position = PoolingManager.Instance.BulletFirstPos.position;
        rb.velocity = PoolingManager.Instance.BulletFirstPos.forward * speed;
    }

    private void OnBecameInvisible()
    {
        this.gameObject.SetActive(false);
    }

}

