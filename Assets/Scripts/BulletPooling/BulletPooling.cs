//using PolygonArsenal;
using System;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.XR;

public class BulletPooling : MonoBehaviour
{
    public int defaultCapacity = 30;
    private List<GameObject> bulletList = new List<GameObject>();
    private int currentBulletIndex = 0;
    private void Start()
    {
        SetCapacity();
    }
    public void SetCapacity()// call up capacity
    {
        for (int i = 0; i < defaultCapacity; i++)
        {
            CreatePooledItem();
        }
    }
    public void CreatePooledItem()//spawn bullet
    {
        //creating a bullet
        GameObject go = Instantiate(PoolingManager.Instance.BulletPrefab,this.transform);

        //Add to the list
        bulletList.Add(go);

        //set position and activity
        //go.transform.position = PoolingManager.Instance.BulletFirstPos.position;
        go.SetActive(false);

        //add component and name
        go.name = "Bullet";
    }
    public void StartShot()
    {
        for(int i = 0;i < PoolingManager.Instance.sourcePositionList.Count;i++)
        {
            ShotNextBullet(PoolingManager.Instance.sourcePositionList[i]);         
        }
    }
    public void ShotNextBullet(Transform pos)//ranking
    {
        if (currentBulletIndex == defaultCapacity)
        {
            currentBulletIndex = 0;
        }
        bulletList[currentBulletIndex].GetComponent<Bullet>().sourcePosition = pos;
        bulletList[currentBulletIndex].SetActive(true);
        currentBulletIndex = (currentBulletIndex + 1) % bulletList.Count;
    }

}

