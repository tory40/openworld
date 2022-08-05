using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    Rigidbody rb;
    Rigidbody[] rbs;
    [SerializeField] 
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rbs = GetComponentsInChildren<Rigidbody>();
    }
    public void Shot(int power) 
    {
        Destroy(gameObject, 5.0f);
        foreach (var rigi in rbs)
        {
            rigi.useGravity = true;
        }
        rb.useGravity = true;
        rb.AddForce(transform.up * power);
    }
}
