using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Beat {
    
    public enum Note {A, B, C, D, NONE};
    private Note n1;
    private Note n2;
    
    public Beat() {
        n1 = Note.NONE;
        n2 = Note.NONE;
    }

    public Beat(Note na, Note nb) {
        n1 = na;
        n2 = nb;
    }

    public void addNote(Note n) {
        if(n1 == Note.NONE) {
            n1 = n;
        }else if (n2 == Note.NONE) {
            n2 = n;
        }
    }

    public string toString() {

        string s = "";
        switch (n1) {
            case Note.NONE:
                s += "-";
                break;
            case Note.A:
                s += "A";
                break;
            case Note.B:
                s += "B";
                break;
            case Note.C:
                s += "C";
                break;
            case Note.D:
                s += "D";
                break;
            default:
                break;

        }
        switch (n2) {
            case Note.NONE:
                s += "--";
                break;
            case Note.A:
                s += "A";
                break;
            case Note.B:
                s += "B";
                break;
            case Note.C:
                s += "C";
                break;
            case Note.D:
                s += "D";
                break;
            default:
                break;

        }

        return s;
    }
    
}
