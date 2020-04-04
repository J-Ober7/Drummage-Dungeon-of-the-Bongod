using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour, PickUpType
{
    public Door door;
    public string Name;
    public void Effect()
    {
        door.openable = true;
    }

    public string ReturnString()
    {
        return "Key";
    }

    public string toString()
    {
        return Name;
    }

    public string Description()
    {
        return "Use this to open " + Name + "!";
    }
}
