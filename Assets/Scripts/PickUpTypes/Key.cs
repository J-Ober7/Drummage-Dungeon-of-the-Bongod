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
        return Name;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
