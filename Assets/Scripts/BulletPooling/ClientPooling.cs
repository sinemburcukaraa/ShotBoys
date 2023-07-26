using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ClientPooling : MonoBehaviour
{
    private BulletPooling _pool;
    public int index;

    void Start()
    {
        _pool = gameObject.AddComponent<BulletPooling>();
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _pool.ShootNextBullet();
        }
    }
    
}