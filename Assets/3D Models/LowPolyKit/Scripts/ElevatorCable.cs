using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorCable : MonoBehaviour
{
    public Transform CableBottom;
    LineRenderer lr;

    private void Start()
    {
        lr = GetComponent<LineRenderer>();
        lr.SetPosition(0, transform.position);
    }

    private void FixedUpdate()
    {
        lr.SetPosition(1, CableBottom.position);
    }
}
