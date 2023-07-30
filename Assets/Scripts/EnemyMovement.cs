using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private Transform pathChart;
    [SerializeField] private PathType pathType;
    [SerializeField] private float hareketSuresi = 5f; // Karakterin hareket etmesi için belirlenen süre

    private Vector3[] pathArray;
    private bool isReversed = false;
    public Animator animator;

   
    void Start()
    {
        animator = GetComponent<Animator>();
        DOVirtual.DelayedCall(2, PathNodes);
    }

    public void PathNodes()
    {
        pathArray = new Vector3[pathChart.childCount];
        for (int i = 0; i < pathArray.Length; i++)
        {
            pathArray[i] = pathChart.GetChild(i).position;
        }

        FollowPath();
    }

    void FollowPath()
    {
        animator.SetBool("run", true);

        if (!isReversed) // Follow the path in normal order
        {
            transform.DOPath(pathArray, hareketSuresi, pathType).SetLookAt(0.001F).OnComplete(ContinueCharacter).SetEase(Ease.Linear).SetId(1);
        }
        else // Follow the path in reverse order
        {
            Vector3[] reversedPath = new Vector3[pathArray.Length];
            for (int i = 0; i < pathArray.Length; i++)
            {
                reversedPath[i] = pathArray[pathArray.Length - 1 - i];
            }

            transform.DOPath(reversedPath, hareketSuresi, pathType).SetLookAt(0.001F).OnComplete(ContinueCharacter).SetEase(Ease.Linear).SetId(0);
        }
    }

    void ContinueCharacter()
    {
        animator.SetBool("run", false);

        isReversed = !isReversed;
        DOVirtual.DelayedCall(2 , FollowPath).SetId(3);
    }
}

