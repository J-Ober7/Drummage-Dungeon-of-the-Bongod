using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerTrap : MonoBehaviour
{
    public GameObject explosion;
    public int damage = 5;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Instantiate(explosion, transform.position, transform.rotation);
            other.gameObject.GetComponent<PlayerBattle>().takeDamage(damage);
        }
       
    }
}
