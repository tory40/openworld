using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using Cinemachine;

public class Camera11 : MonoBehaviour
{
    [SerializeField] Transform arroeset;
    [SerializeField] Transform arrowset;
    [SerializeField] Transform watchtarget;
    [SerializeField] Transform neck;
    [SerializeField] Transform move;
    [SerializeField] CinemachineVirtualCamera camera1;
    [SerializeField] CinemachineVirtualCamera camera2;
    [SerializeField] CinemachineVirtualCamera camera3;
    [SerializeField] CinemachineVirtualCamera camera4;
    [SerializeField] AudioListener main;
    [SerializeField] AudioListener sub;
    [SerializeField] Arrow arrow;
    [SerializeField] Slider slider;
    bool oncamera = false;
    const double MIN = -40;
    const double MAX = 40;
    [SerializeField] Transform eyes;
    double i;
    int power = 0;
    Arrow arrowObj;
    bool down = false;

    public void Start()
    {
        camera1.Priority = 11;
        camera2.Priority = 10;
        camera3.Priority = 10;
        camera4.Priority = 11;
        main.enabled = false;
        sub.enabled = true;
    }
    protected virtual void LateUpdate()
    {
        //ƒJƒƒ‰‚ÌˆÚ“®‚É‡‚í‚¹‚ÄŽñ‚à‰ñ“]
        Vector3 necklotate = new Vector3( 0,0, watchtarget.rotation.x);
        neck.Rotate(necklotate*-180);
    }
    public void Update()
    {
        if (!Timer.end)
        {
            //ƒJƒƒ‰‚Ì‰ñ“]‚ÆÅ‘å’l‚ÌÝ’è
            double h = Input.GetAxis("TurnHorizontal") * .05;
            i += h;
            i = Math.Min(i, MAX);
            i = Math.Max(i, MIN);
            if (i == MAX && h > 0)
            {
                h = 0;
            }
            if (i == MIN && h < 0)
            {
                h = 0;
            }
            eyes.transform.Rotate(new Vector3((float)h, 0, 0));
            if (Timer.start)
            {
                if (Input.GetButtonDown("Arrowinstantiate"))
                {
                    arrowObj = Instantiate(arrow, arroeset.transform.position, arrowset.transform.rotation);
                }
                if (Input.GetButton("Arrowinstantiate"))
                {
                    if (!down)
                    {
                        power += 20;
                        if (power > 4999)
                        {
                            down = true;
                        }
                    }
                    else
                    {
                        power -= 20;
                        if (power < 1)
                        {
                            down = false;
                        }
                    }
                    slider.value = power;
                }
                if (Input.GetButtonUp("Arrowinstantiate"))
                {
                    arrowObj.Shot(power);
                    power = 0;
                    down = false;
                }
                if (Input.anyKeyDown)
                {
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
                                    main.enabled = false;
                                    sub.enabled = true;
                                }
                                else
                                {
                                    oncamera = true;
                                    camera1.Priority = 11;
                                    camera2.Priority = 10;
                                    camera3.Priority = 10;
                                    camera4.Priority = 11;
                                    main.enabled = true;
                                    sub.enabled = false;
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
