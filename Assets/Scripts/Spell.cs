using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spell
{
    public enum Type { Attack, Slow, Haste };
    public string Name;
    public Pattern castPattern;
    private int spellValue;
    public Type type;

    // Update is called once per frame
    public Spell(string name, Pattern p, Type t, int sv) {
        Name = name;
        castPattern = p;
        type = t;
        spellValue = sv;
    }

    public void Cast(PlayerBattle p, EnemyBattle e) {
        if(type == Type.Attack) {
            CastAttack(e);
        }
    }

    private void CastAttack(EnemyBattle e) {
        e.Health -= spellValue;
    }



}
