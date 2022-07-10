using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    Rigidbody rb;
    Rigidbody[] rbs;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rbs = GetComponentsInChildren<Rigidbody>();
    }
    public void Shot(int power) 
    {
        foreach(var rigi in rbs)
        {
            rigi.useGravity = true;
        }
        rb.useGravity = true;
        power = Mathf.Clamp(1000, power, 5000);
        rb.AddForce(transform.up * power);
    }
}
