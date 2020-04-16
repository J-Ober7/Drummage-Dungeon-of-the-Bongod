using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBattle : MonoBehaviour
{
    public int Health;
    public int currHealth;
    public int Speed;
    public Pattern attack;
    public int damageValue;
    private GameObject referenceObject;
    public LevelController lc;
    public Animator anim;
    public bool boss = false;

    public EnemyBattle(int H, int S, Pattern p, int d, GameObject g) {
        Health = H;
        Speed = S;
        attack = p;
        damageValue = d;
        referenceObject = g;
    }


    // Start is called before the first frame update
    void Start()
    {
        currHealth = Health;
        lc = GameObject.FindGameObjectWithTag("GameController").GetComponent<LevelController>();
        randomAttack();
    }

    // Update is called once per frame
    void Update()
    {
        if(!lc)
        {
            lc = GameObject.FindGameObjectWithTag("GameController").GetComponent<LevelController>();
        } 

    }

    private void randomAttack() {
        Beat.Note[] notes = new Beat.Note[] { Beat.Note.A, Beat.Note.B, Beat.Note.C, Beat.Note.D, Beat.Note.NONE };
        Beat[] beats = new Beat[4];
        for(int ii = 0; ii < 4; ++ii) {
            beats[ii] = new Beat(notes[Random.Range(0, 5)], notes[Random.Range(0, 5)]);
        }

        attack = new Pattern(beats[0], beats[1], beats[2], beats[3]);
    }

    public void takeDamage(int d)
    {
        anim.SetTrigger("Damage");
        currHealth -= d;
        CheckDeath();
    }
    public void AttackPlayer(PlayerBattle p)
    {
        anim.SetTrigger("Attack");
        p.takeDamage(damageValue);
    }
    public void applyWeakness(int w)
    {
        if(damageValue > w)
        {
            damageValue -= w;
        }
        else
        {
            damageValue = 1;
        }
    }

    public void CheckDeath() {
        if (currHealth <= 0) {
            anim.SetTrigger("Death");
            lc.endBattle();
            GetComponent<BoxCollider>().enabled = false;
            float t = 0;
            while (t < 1.6)
            {
                t += Time.deltaTime;
            }
            if (boss)
            {
                LevelController.winGame();
            }
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //EnemyBattle hold = other.gameObject.GetComponent<EnemyBattle>();//new EnemyBattle()
            //EnemyBattle enemy = this;//new EnemyBattle()

            lc.enterBattle(this);
        }
    }
}
