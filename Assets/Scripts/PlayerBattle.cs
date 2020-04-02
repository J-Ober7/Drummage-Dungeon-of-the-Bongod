using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBattle : MonoBehaviour
{
    public int maxHealth = 10;
    private int currentHealth;
    public int Speed = 4;
    public Spell[] Spellbook;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        Spell Firebolt = new Spell("Firebolt",
            new Pattern(new Beat(Beat.Note.A), new Beat(Beat.Note.D), new Beat(Beat.Note.A), new Beat(Beat.Note.D)),
            Spell.Type.Attack, 3);
        Spell MinorHeal = new Spell("Minor Heal",
            new Pattern(new Beat(Beat.Note.C, Beat.Note.D), new Beat(Beat.Note.B, Beat.Note.C), new Beat(Beat.Note.B), new Beat(Beat.Note.D)),
            Spell.Type.Attack, 3);
        Spellbook = new Spell[] {Firebolt, MinorHeal};
    }

    // Update is called once per frame
    void Update()
    {
       if(currentHealth <= 0) {
            LevelController.loseGame();
        }
    }

    public string getHealth() {
        return currentHealth.ToString();
    }

    public void takeDamage(int damage) {
        currentHealth -= damage;
    }

    public void heal(int damage)
    {
        if (currentHealth + damage > maxHealth) {
            currentHealth = maxHealth;
        }
        else {
            currentHealth += damage;
        }
    }
}
