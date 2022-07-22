using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CeterOfMassSet : MonoBehaviour
{
    Vector3 com;
    Rigidbody rb;

    // Update is called once per frame
    void Start()
    {
        com = -30f * transform.forward;
        rb = GetComponent<Rigidbody>();
        rb.centerOfMass = com;
    }
}
