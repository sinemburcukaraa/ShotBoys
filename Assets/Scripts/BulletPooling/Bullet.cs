using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.XR;
using static UnityEngine.GraphicsBuffer;

public class Bullet : MonoBehaviour
{
    int speed = 30;
    Rigidbody rb;

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
            this.gameObject.SetActive(false);
        }
    }
    public void Fire()
    {
        rb.velocity = Vector3.forward * speed;

    }

}

