using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField] Text timerText;
    [SerializeField] Text startText;
    private float second=90;
    public static bool start =false;
    public static bool end = false;
    private float startsecond =3.5f;
    // Start is called before the first frame update
    [SerializeField] GameObject panel;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!end)
        {
            if (start)
            {
                second -= Time.deltaTime;
                timerText.text = ((int)(second / 60)).ToString("00") + ":" + (second % 60).ToString("00.00");
            }
            else
            {
                startsecond -= Time.deltaTime;
                startText.text = startsecond.ToString("0");
                if (startsecond < 0.5)
                {
                    start = true;
                    startText.text = "";
                }
            }
        }
        if(second<0)
        {
            end = true;
            panel.SetActive(true);
            GameManager.End();
        }
    }
}
