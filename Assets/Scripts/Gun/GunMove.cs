using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunMove : MonoBehaviour
{
    public float rotateDuration = 1f;

    private void Start()
    {
        RotateZContinuously();
    }

    private void RotateZContinuously()
    {
       
        transform.DORotate(new Vector3(90f, 0f, 45f), rotateDuration).SetEase(Ease.Linear).OnComplete(() =>
        {
            transform.DORotate(new Vector3(90f, 0f, -45f), rotateDuration).SetEase(Ease.Linear).OnComplete(() =>
            {
                RotateZContinuously();
            });
        });
    }
}

