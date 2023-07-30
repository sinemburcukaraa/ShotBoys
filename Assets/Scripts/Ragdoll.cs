using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class Ragdoll : MonoBehaviour
{
    public Rigidbody[] rigidbodies;
    public Collider[] colliders;
    private void Start()
    {
        for (int i = 0; i < rigidbodies.Length; i++)
        {
            rigidbodies[i].isKinematic = true;
            colliders[i].enabled = false;
            rigidbodies[i].mass = 0;
        }
    }

    public void RagdollActive(bool state)
    {
        for (int i = 0; i < rigidbodies.Length; i++)
        {
            rigidbodies[i].isKinematic = !state;
            colliders[i].enabled = state;

        }
        Organise();
    }
    public void Organise()
    {
        EditText();
        DOTween.Kill(0); DOTween.Kill(1); DOTween.Kill(3);
        this.GetComponent<EnemyMovement>().enabled = false;
        this.GetComponent<Animator>().enabled = false;
        this.GetComponent<Rigidbody>().useGravity = true;
        this.GetComponent<Rigidbody>().AddForce(Vector3.up * 500000* Time.deltaTime);

    }
    public void EditText()
    {
        EnemyManager.instance.enemyCount--;
        UIManager.instance.WriteText();
    }
}
