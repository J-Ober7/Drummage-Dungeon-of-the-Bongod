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
    static bool dead = false;
    public GameObject canvas;
    public GameObject deadscreen;
    // Start is called before the first frame update
    void Start()
    {
        NextLevel = nextL;
    }
    private void Update()
    {
        if (dead)
        {
            canvas.SetActive(false);
            deadscreen.SetActive(true);
            dead = false;
            Invoke("LoadLost", 4f);
        }
    }

    public void enterBattle(EnemyBattle enemy) {
        //battleController.player = player;
        aud.Pause();
        player.gameObject.transform.LookAt(enemy.gameObject.transform.position,Vector3.up);
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
        player.transform.rotation = Quaternion.identity;
    }

    public static void winGame() {
        SceneManager.LoadScene(NextLevel);

    }
    public static void loseGame() {
        dead = true;
    }

    public void LoadLost()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
