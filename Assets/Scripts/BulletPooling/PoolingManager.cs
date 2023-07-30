using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PoolingManager : MonoBehaviour
{
    public GameObject BulletPrefab;
    public List<Transform> sourcePositionList=new List<Transform>();    
    public static PoolingManager Instance;

    private void Awake()
    {
        if (!Instance) { Instance = this; }
    }
}
