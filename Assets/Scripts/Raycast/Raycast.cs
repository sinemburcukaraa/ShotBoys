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
    void Start()
    {
        outOfOrder = 1 << 6;
        lr = GetComponent<LineRenderer>();
    }
    void FixedUpdate()
    {
        lr.SetPosition(0, transform.position);

        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, lrPower, outOfOrder))
        {
            if (hit.collider)
            {
                secondPosForRaycast = hit.point;
                secondPosForRaycast.y = lr.GetPosition(0).y;
                lr.SetPosition(1, secondPosForRaycast);
            }
        }
        else
        {
            secondPosForRaycast = transform.TransformDirection(Vector3.forward) * lrPower;
            secondPosForRaycast.y = lr.GetPosition(0).y;
            lr.SetPosition(1, secondPosForRaycast);
        }

    }

}
