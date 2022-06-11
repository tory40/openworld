using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Cinemachine;

public class Camera11 : MonoBehaviour
{
    [SerializeField] Transform watchtarget;
    [SerializeField] Transform neck;
    [SerializeField] Transform move;
    [SerializeField] CinemachineVirtualCamera camera1;
    [SerializeField] CinemachineVirtualCamera camera2;
    [SerializeField] CinemachineVirtualCamera camera3;
    [SerializeField] CinemachineVirtualCamera camera4;
    bool oncamera = false;
    private float eye=0;
    [SerializeField] Transform eyes;

    public void Start()
    {
        camera1.Priority = 10;
        camera2.Priority = 11;
        camera3.Priority = 11;
        camera4.Priority = 10;
    }
    protected virtual void LateUpdate()
    {
        Vector3 necklotate = new Vector3( 0,0, watchtarget.rotation.x);
        Debug.Log(necklotate);
        neck.Rotate(necklotate*-180);
    }
    public void Update()
    {
        if (Input.anyKeyDown) 
        {
            float h = Input.GetAxis("TurnHorizontal");
            eyes.transform.Rotate(new Vector3(h, 0, 0));
            foreach (KeyCode code in Enum.GetValues(typeof(KeyCode)))
            {
                if (Input.GetKeyDown(code))
                {
                    if (code == KeyCode.T)
                    {
                        if (oncamera) 
                        {
                            oncamera = false;
                            camera1.Priority = 10;
                            camera2.Priority = 11;
                            camera3.Priority = 11;
                            camera4.Priority = 10;
                        }
                        else
                        {
                            oncamera = true;
                            camera1.Priority = 11;
                            camera2.Priority = 10;
                            camera3.Priority = 10;
                            camera4.Priority = 11;
                        }
                    }
                }
            }
        }
    }
      
}
