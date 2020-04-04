using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLogic : MonoBehaviour
{
    public LevelController lc;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.CompareTag("Enemy")) {
            //lc.enterBattle(collision.gameObject.GetComponent<EnemyBattle>());
        }
    }

    /*private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Enemy")) {
            //EnemyBattle hold = other.gameObject.GetComponent<EnemyBattle>();//new EnemyBattle()
            EnemyBattle enemy = other.gameObject.GetComponent<EnemyBattle>();//new EnemyBattle()

            lc.enterBattle(other.gameObject.GetComponent<EnemyBattle>());
        }
    }*/
}
