using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBattle : MonoBehaviour
{
    public int Health;
    public int Speed;
    public Pattern attack;
    public int damageValue;
    private GameObject referenceObject;

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
        randomAttack();
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    private void randomAttack() {
        Beat.Note[] notes = new Beat.Note[] { Beat.Note.A, Beat.Note.B, Beat.Note.C, Beat.Note.D, Beat.Note.NONE };
        Beat[] beats = new Beat[4];
        for(int ii = 0; ii < 4; ++ii) {
            beats[ii] = new Beat(notes[Random.Range(0, 5)], notes[Random.Range(0, 5)]);
        }

        attack = new Pattern(beats[0], beats[1], beats[2], beats[3]);


    }
    public void CheckDeath() {
        if (Health <= 0) {
            LevelController.endBattle();
            Destroy(referenceObject);
        }
    }
}
