using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class Ragdoll : MonoBehaviour
{
    public Rigidbody[] rigidbodies;
    public Collider[] colliders;
    public bool ragdollUsed = false;
    private void Start()
    {
        for (int i = 0; i < rigidbodies.Length; i++)
        {
            rigidbodies[i].isKinematic = true;
            colliders[i].enabled = false;
        }
    }

    public void RagdollActive(bool state)
    {
        if (!ragdollUsed)
        {
            for (int i = 0; i < rigidbodies.Length; i++)
            {
                rigidbodies[i].isKinematic = !state;
                colliders[i].enabled = state;

            }
            Organise();
            ragdollUsed=true;
        }
   
    }
    public void Organise()
    {
        this.GetComponent<EnemyMovement>().DotweenKill();
        this.GetComponent<EnemyMovement>().enabled = false;
        this.GetComponent<Animator>().enabled = false;
        this.GetComponent<Rigidbody>().useGravity = true;
        //this.GetComponent<Rigidbody>().AddForce(Vector3.up * 500000 *Time.deltaTime);
        EditText();

    }
    public void EditText()
    {
        EnemyManager.instance.enemyCount--;
        UIManager.instance.WriteText();
    }
}
