using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pattern : ScriptableObject
{

    public Beat[] beats;
    // Start is called before the first frame update
    public Pattern() {
        beats = new Beat[] { new Beat(), new Beat(), new Beat(), new Beat() };
    }

    public Pattern(Beat b1, Beat b2, Beat b3, Beat b4) {
        beats = new Beat[] { b1, b2, b3, b4 };
    }

    // Update is called once per frame
    public void addNote(Beat.Note note, int count) {
        
        beats[count].addNote(note);


    }

    public string toString() {
        string s = "";
        s += beats[0].toString();
        s += " ";
        s += beats[1].toString();
        s += " ";
        s += beats[2].toString();
        s += " ";
        s += beats[3].toString();
        s += "|";

        return s;
    }
}
