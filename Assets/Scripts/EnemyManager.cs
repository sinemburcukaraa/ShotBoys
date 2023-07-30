using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public static EnemyManager instance;
    public int enemyCount;
    private void Awake()
    {
        if (instance == null) { instance = this; }
    }
   
}
