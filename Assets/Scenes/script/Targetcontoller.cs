using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Targetcontoller : MonoBehaviour
{
    [SerializeField] TargetInstance target;
    Targetview view;
    Targetmodel model;
    private void Awake()
    {
        view = GetComponent<Targetview>();
    }

    public void Init(int targetnum)
    {
        model = new Targetmodel(targetnum);
        view.Show(model);

    }
    void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
        Debug.Log(collision.gameObject.tag);
        target.Target();

    }
}
