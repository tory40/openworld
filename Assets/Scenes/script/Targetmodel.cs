using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Targetmodel
{
    public int point;
    public Targetmodel(int targetnum)
    {
        if(targetnum!=2)
        {
            point = 1;
        }
        else
        {
            point = 3;
        }
    }
}
