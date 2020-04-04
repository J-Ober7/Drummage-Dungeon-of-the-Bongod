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
    private int totalMeasures = 5;
    //private float measureTimer;

    public TextMeshProUGUI PlannedInput;
    public TextMeshProUGUI InputText;
    public TextMeshProUGUI PlayerHealth;
    public TextMeshProUGUI EnemyHealth;
    private Pattern[] InputMeasures;
    private bool start; //should a round of combat start
    public AudioSource beep;
    public AudioSource ANote;
    public AudioSource BNote;
    public AudioSource CNote;
    public AudioSource DNote;
    // Start is called before the first frame update
    void Start()
    {
        //gameObject.SetActive(false);
        InputMeasures = new Pattern[] { new Pattern(), new Pattern(), new Pattern(), new Pattern(), new Pattern()};
        createSelections();
        startTimer = 5;
        bps = tempo / 60;
        beatTime = 0;
        beatCount = 0;
        measure = 0;
        prevCount = 3;
        start = false;

}
    private void OnEnable() {
        InputMeasures = new Pattern[] { new Pattern(), new Pattern(), new Pattern(), new Pattern(), new Pattern()};
        createSelections();
        startTimer = 5;
        bps = tempo / 60;
        beatTime = 0;
        beatCount = 0;
        measure = 0;
        prevCount = 3;
        start = false;
    }

    // Update is called once per frame
    void Update()
    {
        EnemyHealth.text = "Enemy Health: " + enemy.Health;
        PlayerHealth.text = "Player Health: " + player.getHealth();
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
            else if(measure < 5) {
                
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
                    InputMeasures[measure].addNote(Beat.Note.B, beatCount);
                    BNote.Play();
                }
                if (Input.GetButtonDown("Backward")) {
                    InputMeasures[measure].addNote(Beat.Note.C, beatCount);
                    CNote.Play();
                }
                if (Input.GetButtonDown("Left")) {
                    InputMeasures[measure].addNote(Beat.Note.A, beatCount);
                    ANote.Play();
                }
                if (Input.GetButtonDown("Right")) {
                    InputMeasures[measure].addNote(Beat.Note.D, beatCount);
                    DNote.Play();
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
                InputMeasures = new Pattern[] { new Pattern(), new Pattern(), new Pattern(), new Pattern(), new Pattern() };
                
            }
            
        }
        else {
            PlannedInput.text = PlannedString();
            InputText.text = "Press a note to start";
            if (Input.GetKeyDown(KeyCode.Space)) {/*Input.GetButton("Forward") || Input.GetButton("Backward") || Input.GetButton("Left") || Input.GetButton("Right")*/
                start = true;
                
            }
        }
        
    }

    //checks if player inputs matches selected measures 
    private void CheckMeasures() {
        
        for(int ii = 0; ii < InputMeasures.Length; ++ii) {
            Debug.Log(ii);
            int k = MeasureSelection[ii].value;
            if (defendMeasures.Contains(ii)) {
                
                if(k!=0) {
                    float t = 0;
                    if (InputMeasures[ii].Equals(player.Spellbook[k - 1].castPattern)) {
                        player.Spellbook[k - 1].Cast(player, enemy);
                        
                        while (t < 1.6)
                        {
                            t += Time.deltaTime;
                        }
                    }
                    enemy.AttackPlayer(player);
                    t = 0;
                    while (t < 1.6)
                    {
                        t += Time.deltaTime;
                    }
                    //player.takeDamage(enemy.damageValue);
                }
                else {
                    if (!InputMeasures[ii].Equals(enemy.attack))
                    {
                        enemy.AttackPlayer(player);
                        float t = 0;
                        while (t < 1.6)
                        {
                            t += Time.deltaTime;
                        }
                    }
                }
            }
            else {
                if (InputMeasures[ii].Equals(player.Spellbook[k].castPattern)) {
                    Debug.Log("Attack!");
                    player.Spellbook[k].Cast(player, enemy);
                }
            }

            EnemyHealth.text = "Enemy Health: " + enemy.currHealth;
            PlayerHealth.text = "Player Health: " + player.maxHealth;
        }
        enemy.CheckDeath();
    }


    private void createSelections() {
        defendMeasures = new List<int>();
        EnemyAndSpells = new List<TMP_Dropdown.OptionData>();
        Spells = new List<TMP_Dropdown.OptionData>();
        EnemyAndSpells.Add(new TMP_Dropdown.OptionData("Defend"));
        foreach(Spell s in player.Spellbook) {
            Debug.Log(s.Name);
            TMP_Dropdown.OptionData spell = new TMP_Dropdown.OptionData(s.Name);
            EnemyAndSpells.Add(spell);
            Spells.Add(spell);
        }

        
        for (int i = 0; i < enemy.Speed; i++) {
            int k = Random.Range(0, totalMeasures);
            MeasureSelection[k].options = EnemyAndSpells;
            defendMeasures.Add(k);
        }

        for(int ii = 0; ii < InputMeasures.Length; ii++) {
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
        for(int ii = 0; ii < 5; ii++) {
            s += InputMeasures[ii].toString();
        }
        return s;
    }

    private string PlannedString() {
        string s = "|";
        for (int ii = 0; ii < 5; ii++) {
            if (defendMeasures.Contains(ii)) {
                if (MeasureSelection[ii].value == 0) {
                    s += enemy.attack.toString();
                }
                else {
                    s += player.Spellbook[MeasureSelection[ii].value - 1].castPattern.toString();
                }
            }
            else {
                s += player.Spellbook[MeasureSelection[ii].value].castPattern.toString();
            }
        }
        return s;
    }
}
