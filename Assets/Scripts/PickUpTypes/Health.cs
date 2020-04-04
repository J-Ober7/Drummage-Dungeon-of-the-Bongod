using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour, PickUpType
{
    public PlayerBattle pb;
    public int health;
    public void Start()
    {
        pb = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerBattle>();
        health = 3;
    }
    public void Effect()
    {
        Debug.Log("health");
        pb.heal(health);
    }

    public string ReturnString()
    {
        return "Health";
    }

    public string Description()
    {
        return "Potion that fills up to 3 health";
    }
    public string toString()
    {
        return "Health Potion";
    }
}
