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
        transform.DOLocalRotate(new Vector3(0, 45f, 0), rotateDuration).SetEase(Ease.Linear).OnComplete(() =>
        {
            transform.DOLocalRotate(new Vector3(0, -45f, 0), rotateDuration).SetEase(Ease.Linear).OnComplete(() =>
            {
                RotateZContinuously();
            });
        });
    }
}

