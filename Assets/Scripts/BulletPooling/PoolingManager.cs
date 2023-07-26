using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PoolingManager : MonoBehaviour
{
    public GameObject BulletPrefab;
    public Transform BulletFirstPos;
    public static PoolingManager Instance;

    private void Awake()
    {
        if (!Instance) { Instance = this; }
    }
}
