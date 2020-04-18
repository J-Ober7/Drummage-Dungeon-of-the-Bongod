using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spell : MonoBehaviour
{
    public enum Type { Attack, Slow, Heal, Weak };
    public string Name;
    public Pattern castPattern;
    private int spellValue;
    public Type type;
    public GameObject vsf;

    // Update is called once per frame
    public Spell(string name, Pattern p, Type t, int sv, GameObject vsf)
    {
        Name = name;
        castPattern = p;
        type = t;
        spellValue = sv;
        this.vsf = vsf;
    }

    public void Cast(PlayerBattle p, EnemyBattle e)
    {
        if (type == Type.Attack)
        {
            CastAttack(e);
        }
        else if (type == Type.Heal)
        {
            CastHeal(p);
        }
        else if (type == Type.Weak)
        {
            CastWeak(e);
        }
    }

    private void CastAttack(EnemyBattle e)
    {
        e.takeDamage(spellValue);
        Instantiate(vsf, e.gameObject.transform.position, e.gameObject.transform.rotation);
    }

    private void CastHeal(PlayerBattle p)
    {
        p.heal(spellValue);
        Instantiate(vsf, p.gameObject.transform.position, p.gameObject.transform.rotation);
    }

    private void CastWeak(EnemyBattle e)
    {
        e.applyWeakness(spellValue);
        Instantiate(vsf, e.gameObject.transform.position, e.gameObject.transform.rotation);
    }



}
