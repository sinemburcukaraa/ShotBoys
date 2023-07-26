using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunMove : MonoBehaviour
{
    public float rotateSpeed = 45f;
    public float rotationThreshold = 45f;

    private float currentRotation = 0f;
    private bool rotateClockwise = true;

    // Update is called once per frame
    void Update()
    {
        // Silahýn dönme açýsýný güncelle
        currentRotation = (currentRotation + rotateSpeed * Time.deltaTime) % 360;

        // Dönme eþiðine ulaþýldýðýnda dönüþ yönünü deðiþtir
        if (currentRotation >= rotationThreshold && rotateClockwise)
        {
            rotateClockwise = false;
        }
        else if (currentRotation <= -rotationThreshold && !rotateClockwise)
        {
            rotateClockwise = true;
        }

        // Silahýn dönme yönüne göre Z ekseninde döndür
        if (rotateClockwise)
        {
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, transform.eulerAngles.z - rotateSpeed * Time.deltaTime);
        }
        else
        {
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, transform.eulerAngles.z + rotateSpeed * Time.deltaTime);
        }
    }
}

