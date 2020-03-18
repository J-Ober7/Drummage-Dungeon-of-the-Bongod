using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface PickUpType
{
    void Effect();

    string ReturnString();
}

public class None :  PickUpType
{
    public void Effect()
    {
        Debug.Log("yeet");
    }

    public string ReturnString()
    {
        return "None";
    }
}


