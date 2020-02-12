using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BattleTest : MonoBehaviour
{
    public float tempo = 60;
    private float bps;
    private float beatTime;
    private int beatCount;
    private int measure;
    //private float measureTimer;
    public TextMeshProUGUI text;
    private Pattern[] measures;
    private bool start;
    private float prevCount;
    private float startTimer;
    public AudioSource beep;
    // Start is called before the first frame update
    void Start()
    {
        measures = new Pattern[] { new Pattern(), new Pattern(), new Pattern(), new Pattern(), new Pattern() };
        startTimer = 5;
        bps =tempo / 60;
        beatTime = 0;
        beatCount = 0;
        measure = 0;
        prevCount = 3;
}

    // Update is called once per frame
    void Update()
    {
        if (start) {
            text.text = toString();
           // if (startTimer <= (5 + (4 * bps))) {
            if (startTimer <= 9) {
                startTimer += Time.deltaTime * bps;
                text.text = Mathf.Floor(startTimer).ToString();
                if(Mathf.Floor(startTimer) > prevCount) {
                    beep.Play();
                    prevCount = Mathf.Floor(startTimer);
                }
                
            }else if(measure < 5) {
                
                if (beatTime == 0) {
                    beep.Play();
                }
                beatTime += Time.deltaTime * bps;
                if(beatTime >= 1) {
                    beatCount++;
                    if(beatCount > 3) {
                        beatCount = 0;
                        measure++;
                    }
                    beatTime = 0;
                }

                if (Input.GetButtonDown("Forward")) {
                    measures[measure].addNote(Beat.Note.B, beatCount);
                }
                if (Input.GetButtonDown("Backward")) {
                    measures[measure].addNote(Beat.Note.C, beatCount);
                }
                if (Input.GetButtonDown("Left")) {
                    measures[measure].addNote(Beat.Note.A, beatCount);
                }
                if (Input.GetButtonDown("Right")) {
                    measures[measure].addNote(Beat.Note.D, beatCount);
                }

                text.text = toString();
            } else {
                measure = 0;
                start = false;
                startTimer = 5;
                measures = new Pattern[] { new Pattern(), new Pattern(), new Pattern(), new Pattern(), new Pattern() };
            }
            
        }
        else {
            text.text = "Press a note to start";
            if (Input.GetButton("Forward") || Input.GetButton("Backward") || Input.GetButton("Left") || Input.GetButton("Right")) {
                start = true;
                
            }
        }
        
    }
    public string toString() {
        string s = "|";
        for(int ii = 0; ii < 5; ii++) {
            s += measures[ii].toString();
        }
        return s;
    }
}
