using PolygonArsenal;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.XR;

public class BulletPooling : MonoBehaviour
{
    public int defaultCapacity = 10;
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
        GameObject go = Instantiate(PoolingManager.Instance.BulletPrefab);

        //Add to the list
        bulletList.Add(go);

        //set position and activity
        go.transform.position = PoolingManager.Instance.BulletFirstPos.position;
        go.SetActive(false);

        //add component and name
        Bullet bullet = go.AddComponent<Bullet>();
        go.name = "Bullet";
    }
    public void ShootNextBullet()//ranking
    {
        if (currentBulletIndex == defaultCapacity)
        {
            currentBulletIndex = 0;
        }

        OnTakeFromPool(currentBulletIndex);
        currentBulletIndex = (currentBulletIndex + 1) % bulletList.Count;
    }

    //public void OnReturnedToPool(int index)
    //{
    //    bulletList[index].SetActive(false);
    //}

    public void OnTakeFromPool(int index)
    {
        bulletList[index].SetActive(true);
    }


}

