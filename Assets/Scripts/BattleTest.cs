using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BattleTest : MonoBehaviour
{
    public float tempo = 60;
    public TMP_Dropdown[] MeasureSelection;
    
    public PlayerBattle player;
    public EnemyBattle enemy;
    private List<int> defendMeasures;
    private float bps;
    private float beatTime;
    private int beatCount;//current beat in the measure
    private int measure;// current measure in the line
    private float prevCount;
    private float startTimer; //counter for the begining of a round to give the player the tempo
    private List<TMP_Dropdown.OptionData> EnemyAndSpells;
    private List<TMP_Dropdown.OptionData> Spells;

    //private float measureTimer;

    public TextMeshProUGUI PlannedInput;
    public TextMeshProUGUI InputText;
    public TextMeshProUGUI PlayerHealth;
    public TextMeshProUGUI EnemyHealth;
    private Pattern[] measures;
    private bool start; //should a round of combat start
    public AudioSource beep;
    // Start is called before the first frame update
    void Start()
    {
        measures = new Pattern[] { new Pattern(), new Pattern(), new Pattern(), new Pattern()};
        createSelections();
        startTimer = 5;
        bps = tempo / 60;
        beatTime = 0;
        beatCount = 0;
        measure = 0;
        prevCount = 3;
}
    private void OnEnable() {
        measures = new Pattern[] { new Pattern(), new Pattern(), new Pattern(), new Pattern() };
        createSelections();
        startTimer = 5;
        bps = tempo / 60;
        beatTime = 0;
        beatCount = 0;
        measure = 0;
        prevCount = 3;
    }

    // Update is called once per frame
    void Update()
    {
        EnemyHealth.text = "Enemy Health: " + enemy.Health;
        PlayerHealth.text = "Player Health: " + player.Health;
        if (start) {
            InputText.text = toString();
           //The Countdown timer before accepting player imput
            if (startTimer <= 9) {
                startTimer += Time.deltaTime * bps;
                InputText.text = Mathf.Floor(startTimer).ToString();
                if(Mathf.Floor(startTimer) > prevCount) {
                    beep.Play();
                    prevCount = Mathf.Floor(startTimer);
                }
                
            }
            //Accepting Player Input
            else if(measure < 4) {
                
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

                InputText.text = toString();
            } 
            //otherwise input stage has ended and the round should be resolved and the state shoud be reset.
            else {
                CheckMeasures();
                measure = 0;
                start = false;
                startTimer = 5;
                prevCount = 3;
                measures = new Pattern[] { new Pattern(), new Pattern(), new Pattern(), new Pattern()};
                
            }
            
        }
        else {
            PlannedInput.text = PlannedString();
            InputText.text = "Press a note to start";
            if (Input.GetButton("Forward") || Input.GetButton("Backward") || Input.GetButton("Left") || Input.GetButton("Right")) {
                start = true;
                
            }
        }
        
    }
    private void CheckMeasures() {
        for(int ii = 0; ii < measures.Length; ++ii) {

            int k = MeasureSelection[ii].value;
            if (defendMeasures.Contains(ii)) {
                
                if(k!=0) {
                    if (measures[ii].Equals(player.Spellbook[k - 1])) {
                        player.Spellbook[k - 1].Cast(player, enemy);
                    }
                }
                else {
                    if (measures[ii].Equals(enemy.attack)) {
                        player.takeDamage(enemy.damageValue);
                    }
                }
            }
            else {
                if (measures[ii].Equals(player.Spellbook[k])) {
                    player.Spellbook[k].Cast(player, enemy);
                }
            }
        }
    }
    private void createSelections() {
        defendMeasures = new List<int>();
        EnemyAndSpells = new List<TMP_Dropdown.OptionData>();
        Spells = new List<TMP_Dropdown.OptionData>();
        EnemyAndSpells.Add(new TMP_Dropdown.OptionData("Defend"));
        foreach(Spell s in player.Spellbook) {
            TMP_Dropdown.OptionData spell = new TMP_Dropdown.OptionData(s.Name);
            EnemyAndSpells.Add(spell);
            Spells.Add(spell);
        }

        
        for (int i = 0; i < enemy.Speed; i++) {
            int k = Random.Range(0, enemy.Speed);
            MeasureSelection[k].options = EnemyAndSpells;
            defendMeasures.Add(k);
        }

        for(int ii = 0; ii < 4; ii++) {
            if (!defendMeasures.Contains(ii)) {
                MeasureSelection[ii].options = Spells;
            }
            else {
                MeasureSelection[ii].options = EnemyAndSpells;
            }
        }

    }
    public string toString() {
        string s = "|";
        for(int ii = 0; ii < 4; ii++) {
            s += measures[ii].toString();
        }
        return s;
    }

    private string PlannedString() {
        string s = "|";
        for (int ii = 0; ii < 4; ii++) {
            if (defendMeasures.Contains(ii)) {
                s += EnemyAndSpells[MeasureSelection[ii].value].ToString();
            }
            else {
                s += Spells[MeasureSelection[ii].value].ToString();
            }
        }
        return s;
    }
}
