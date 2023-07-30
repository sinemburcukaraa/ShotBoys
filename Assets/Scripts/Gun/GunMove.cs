using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunMove : MonoBehaviour
{
    public float rotateDuration = 1f;
    public Vector3[] directionOfRotation = new Vector3[2];
    bool isStarted = false;
    private void Update()
    {
        GameState();
    }
    public void GameState()
    {
        if (GameManager.instance.gameSit == GameManager.GameSit.Started && !isStarted)
        {
            isStarted = true;
            RotateZContinuously();
        }
        else if(GameManager.instance.gameSit == GameManager.GameSit.Win || GameManager.instance.gameSit == GameManager.GameSit.GameOver && isStarted)
        {
            DOTween.Kill(0);DOTween.Kill(1);
        }
       
    }
    private void RotateZContinuously()
    {
        transform.DOLocalRotate(directionOfRotation[0], rotateDuration).SetEase(Ease.Linear).SetId(0).OnComplete(() =>
        {
            transform.DOLocalRotate(directionOfRotation[1], rotateDuration).SetEase(Ease.Linear).SetId(1).OnComplete(() =>
            {
                RotateZContinuously();
            });
        });
    }
}

