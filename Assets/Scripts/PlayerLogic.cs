using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLogic : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionStay(Collision collision) {
        if (collision.gameObject.CompareTag("Enemy")) {
            SceneManager.LoadScene("BattleTestScene");
        }
    }

    private void OnTriggerStay(Collider other) {
        if (other.CompareTag("Enemy")) {
            SceneManager.LoadScene("BattleTestScene");
        }
    }
}
