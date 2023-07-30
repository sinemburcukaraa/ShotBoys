using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;

public class Raycast : MonoBehaviour
{
    public LineRenderer lr;
    public int lrPower;
    public LayerMask outOfOrder;
    Vector3 secondPosForRaycast;
    bool isHit;

    void Start()
    {
        outOfOrder = LayerMask.GetMask("Raycast");
        lr = GetComponent<LineRenderer>();
        isHit = false;
    }

    void Update()
    {
        lr.SetPosition(0, transform.position);

        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, lrPower, outOfOrder))
        {
            if (hit.collider)
            {
                isHit = true;
                secondPosForRaycast = hit.point;
                secondPosForRaycast.y = lr.GetPosition(0).y;
            }
        }
        else
        {
            isHit = false;
        }
        collisionDetected();


    }
    public void collisionDetected()
    {
        if (isHit)
        {
            lr.SetPosition(1, secondPosForRaycast);
        }
        else
        {
            secondPosForRaycast = transform.position + transform.forward * lrPower;
            secondPosForRaycast.y = lr.GetPosition(0).y;
            lr.SetPosition(1, secondPosForRaycast);
        }
    }

}
