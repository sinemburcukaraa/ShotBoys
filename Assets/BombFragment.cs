using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombFragment : MonoBehaviour
{
    List<GameObject> bombFragments = new List<GameObject>();
   
    private void Start()
    {
        for (int i = 0; i < this.transform.childCount; i++)
        {
            bombFragments.Add(this.transform.GetChild(i).gameObject);
        }
    }

    public void Fragment()
    {
        for (int i = 0; i < bombFragments.Count; i++)
        {
           FragmentMovement(bombFragments[i]);
        }
    }
    public void FragmentMovement(GameObject fragment)
    {
        fragment.GetComponent<Rigidbody>().useGravity = true;
        fragment.GetComponent<MeshCollider>().enabled = true;
    }
}
