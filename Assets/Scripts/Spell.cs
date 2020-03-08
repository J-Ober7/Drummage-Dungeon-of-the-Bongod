using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spell
{
    public enum Type { Attack, Slow, Haste };
    public string Name;
    public Pattern castPattern;
    public Type type;
    // Update is called once per frame
    public Spell(string name, Pattern p, Type t) {
        Name = name;
        castPattern = p;
        type = t;
    }

    public void Cast(PlayerBattle p, EnemyBattle e) {

    }



}
