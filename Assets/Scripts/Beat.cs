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
        if (na == Note.NONE && nb != Note.NONE) {
            n1 = nb;
            n2 = Note.NONE;
        }
        else {
            n1 = na;
            n2 = nb;
        }
    }
    public Beat(Note na) {
        n1 = na;
        n2 = Note.NONE;
    }

    public void addNote(Note n) {
        if(n1 == Note.NONE) {
            n1 = n;
        }else if (n2 == Note.NONE) {
            n2 = n;
        }
    }
    public bool Equals(Beat other) {
        if(other == null) {
            return false;
        }
        return (n1 == other.n1) && (n2 == other.n2);
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
                s += "W";
                break;
            case Note.C:
                s += "S";
                break;
            case Note.D:
                s += "D";
                break;
            default:
                break;

        }
        switch (n2) {
            case Note.NONE:
                s += "-";
                break;
            case Note.A:
                s += "A";
                break;
            case Note.B:
                s += "W";
                break;
            case Note.C:
                s += "S";
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
