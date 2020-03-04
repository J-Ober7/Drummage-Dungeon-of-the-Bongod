using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PickUpType
{
    Health, None
}


//might need this for methods in this class but we'll see
public static class PickUpTypeMethods
{
    public static void Effect(this PickUpType put)
    {
        switch(put)
        {
            case PickUpType.Health:
                Debug.Log("Health");
                return;
            default:
                Debug.Log("None"); return;
        }
    }
}
