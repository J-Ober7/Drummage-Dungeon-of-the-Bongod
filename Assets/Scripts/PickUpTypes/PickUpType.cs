using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface PickUpType
{
    void Effect();

    string ReturnString();

    string Description();

    string toString();
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

    public string Description()
    {
        return "You have space in your inventory!";
    }


    public string toString()
    {
        return "None";
    }
}


