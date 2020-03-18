using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBattle : MonoBehaviour
{
    public int Health = 10;
    public int Speed = 4;
    public Spell[] Spellbook;

    // Start is called before the first frame update
    void Start()
    {
        //Speed;
        Spell Firebolt = new Spell("Firebolt",
            new Pattern(new Beat(Beat.Note.A), new Beat(Beat.Note.D), new Beat(Beat.Note.A), new Beat(Beat.Note.D)),
            Spell.Type.Attack, 3);

        Spellbook = new Spell[] {Firebolt};
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void takeDamage(int damage) {
        Health -= damage;
    }

    public void heal(int damage)
    {
        Health += damage;
    }
}
