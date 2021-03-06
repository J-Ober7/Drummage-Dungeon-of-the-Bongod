﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerBattle : MonoBehaviour
{
    public int maxHealth = 10;
    private int currentHealth;
    public int Speed = 4;
    public Spell[] Spellbook;
    public TextMeshProUGUI healthText;
    public GameObject fireboltAnimation;
    public GameObject healAnimation;
    public GameObject weakenAnimation;
    public GameObject blockAnimation;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        Spell Firebolt = new Spell("Firebolt",
            new Pattern(new Beat(Beat.Note.A), new Beat(Beat.Note.D), new Beat(Beat.Note.A), new Beat(Beat.Note.D)),
            Spell.Type.Attack, 3, fireboltAnimation);
        Spell MinorHeal = new Spell("Minor Heal",
            new Pattern(new Beat(Beat.Note.C, Beat.Note.D), new Beat(Beat.Note.B), new Beat(Beat.Note.A), new Beat(Beat.Note.D)),
            Spell.Type.Heal, 1, healAnimation);
        Spell Weaken = new Spell("Weaken",
            new Pattern(new Beat(Beat.Note.D, Beat.Note.A), new Beat(Beat.Note.C), new Beat(Beat.Note.B), new Beat(Beat.Note.D, Beat.Note.A)),
            Spell.Type.Weak, 1, weakenAnimation);

        Spellbook = new Spell[] { Firebolt, MinorHeal, Weaken };
    }

    // Update is called once per frame
    void Update()
    {
        healthText.text = "Health: " + currentHealth;
        if (currentHealth <= 0)
        {
            LevelController.loseGame();
        }
    }

    public string getHealth()
    {
        return currentHealth.ToString();
    }

    public void takeDamage(int damage)
    {
        currentHealth -= damage;
    }

    public void heal(int heal)
    {
        if (currentHealth + heal > maxHealth)
        {
            currentHealth = maxHealth;
        }
        else
        {
            currentHealth += heal;
        }
    }
}
