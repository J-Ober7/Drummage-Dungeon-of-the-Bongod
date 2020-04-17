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
    public string nextL;
    static string NextLevel;
    public AudioSource aud;
    // Start is called before the first frame update
    void Start()
    {
        NextLevel = nextL;
    }

    public void enterBattle(EnemyBattle enemy) {
        //battleController.player = player;
        aud.Pause();
        battleController.enemy = enemy;
        BattleBlock.SetActive(true);
        //Debug.Log("tests");
        //battleController.enabled = true;
        inCombat = true;
    }

    public void endBattle() {
        aud.Play();
        BattleBlock.SetActive(false);
        inCombat = false;
    }

    public static void winGame() {
        SceneManager.LoadScene(NextLevel);

    }
    public static void loseGame() {
        SceneManager.LoadScene("Lose");

    }
}
