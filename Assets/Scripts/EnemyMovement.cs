using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private Transform pathChart;
    [SerializeField] private PathType pathType;
    [SerializeField] private float hareketSuresi = 5f; 

    private Vector3[] pathArray;
    private bool isReversed = false;
    public Animator animator;
    bool isStarted = false;
    Sequence mySequence, mySequence2, mySequence3;
    public bool used;
    private void Update()
    {
        GameState();

    }
    public void GameState()
    {

        if (GameManager.instance.gameSit == GameManager.GameSit.Started && !isStarted)
        {
            isStarted = true;
            animator = GetComponent<Animator>();

            PathNodes();
        }

        
    }
    public void PathNodes()
    {
        pathArray = new Vector3[pathChart.childCount];
        for (int i = 0; i < pathArray.Length; i++)
        {
            pathArray[i] = pathChart.GetChild(i).position;
        }

        if (!used)
        {
            FollowPath();

        }

    }

    void FollowPath()
    {
        enemyAnimator(true);

        if (!isReversed) // Follow the path in normal order
        {
            mySequence = DOTween.Sequence();
            mySequence.Append(transform.DOPath(pathArray, hareketSuresi, pathType).SetLookAt(0.001F).OnComplete(ContinueCharacter).SetEase(Ease.Linear));

        }
        else // Follow the path in reverse order
        {
            Vector3[] reversedPath = new Vector3[pathArray.Length];
            for (int i = 0; i < pathArray.Length; i++)
            {
                reversedPath[i] = pathArray[pathArray.Length - 1 - i];
            }

            mySequence2 = DOTween.Sequence();
            mySequence2.Append(transform.DOPath(reversedPath, hareketSuresi, pathType).SetLookAt(0.001F).OnComplete(ContinueCharacter).SetEase(Ease.Linear));

        }
    }

    void ContinueCharacter()
    {

        enemyAnimator(false);
        isReversed = !isReversed;


        mySequence3 = DOTween.Sequence();
        mySequence3.Append(DOVirtual.DelayedCall(2, FollowPath));
    }

    public void DotweenKill()
    {
        if (mySequence != null && mySequence.IsActive())
        {
            mySequence.Kill();
        }

        if (mySequence2 != null && mySequence2.IsActive())
        {
            mySequence2.Kill();
        }

        if (mySequence3 != null && mySequence3.IsActive())
        {
            mySequence3.Kill();

        }

    }
    public void enemyAnimator(bool state)
    {
        if (animator == null)
        {
            return;
        }

        animator.SetBool("run", state);
    }
}
