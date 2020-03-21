using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    public PlayerBattle player;
    //public EnemyBattle enemy;
    public static bool inCombat = false;
    public GameObject BattleBlock;
    public BattleTest battleController;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void enterBattle(EnemyBattle enemy) {
        //battleController.player = player;
        battleController.enemy = enemy;
        BattleBlock.SetActive(true);
        //Debug.Log("tests");
        //battleController.enabled = true;
        inCombat = true;
    }

    public void endBattle() {
        BattleBlock.SetActive(false);
        inCombat = false;
    }

    public static void winGame() {
        SceneManager.LoadScene("TutorialBeat");

    }
    public static void loseGame() {
        SceneManager.LoadScene("Lose");

    }
}
