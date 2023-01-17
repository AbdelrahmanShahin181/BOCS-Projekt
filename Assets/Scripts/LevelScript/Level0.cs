using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Level0 : MonoBehaviour
{
    public GameObject dialogBox;
    public Text dialogText;
    public string[][] dialog;
    public bool playerInRange;
    public HealthManager healthManager;
    public HealthBarScript healthBarScript;
    public Timeline timeline;
    public bool dialogActive = false;

    private int counter = 0;
    

    private void Start() {
        timeline = GameObject.Find("Timeline").GetComponent<Timeline>();

        dialog = new string[6][];
        dialog[0] = new string[8];
        dialog[0][0] = "Hallo und Herzlich Willkommen!";
        dialog[0][1] = "Schön, dass du dich für die ein Studium an der {Hochschule Bochum} entschieden hast.";	
        dialog[0][2] = "Du befindest dich im Eingangsbereich der FH. Es liegt im {A} Gebäude.";
        dialog[0][3] = "Die Hörsääle befinden sich im {B} Gebäude.";
        dialog[0][4] = "Praktische Arbeiten in Laborräumen werden im {C} Gebäude durchgeführt.";
        dialog[0][5] = "Dort findest du auch die zentrale Studienberatung sowie die Studierendenbüros.";
        dialog[0][6] = "Gehe bitte zur Mensa, um etwas zu essen.";
        dialog[0][7] = "Du findest die Mensa, indem du nach Oben an den Fahrstühlen vorbei läufst.";
        dialog[1] = new string[2];
        dialog[1][0] = "Hast du schon was gegessen?";
        dialog[1][1] = "gehe bitte zur Mensa mein Lieber";
        dialog[2] = new string[2];
        dialog[2][0] = "Du hast das erste Semester schon abgeschlossen?";
        dialog[2][1] = "Dann müsstest du doch jetzt in der Mathe 2 Vorlesung in H9 sitzen.";
        dialog[3] = new string[2];
        dialog[3][0] = "Ich hab von deinem Snake Rekord gehört.";
        dialog[3][1] = "Einer der Studenten vor dem Haupteingang möchte dich sprechen.";
        dialog[4] = new string[3];
        dialog[4][0] = "Ich habe dich von hier vor der Hochschule herfahren gesehen.";
        dialog[4][1] = "Du hast alle anderen ja wirklich abgehängt.";
        dialog[4][2] = "Aber jetzt solltest du mal nach den Dozenten im C-Gebäude sehen.";
        dialog[5] = new string[2];
        dialog[5][0] = "Vielen Dank fürs Spielen!";
        dialog[5][1] = "Du hast das Ende dieser Version erreicht!";
    }
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E) && playerInRange)
        {
            
            if(dialogBox.activeInHierarchy && dialogActive)
            {
                if(counter >= dialog[timeline.level].Length)
                {
                    dialogBox.SetActive(false);
                    dialogActive = false;
                    counter = 0;
                    if(timeline.level == 0)
                        timeline.level = timeline.level + 1;
                    
                    Debug.Log("Level 1");
                }
                else
                {
                    dialogText.text = dialog[timeline.level][counter];
                    counter++;
                }
            }
            else if(!dialogActive)
            {
                dialogBox.SetActive(true);
                dialogText.text = dialog[timeline.level][0];
                counter = 1;
                dialogActive = true;
            }
        }
        if(dialogBox.activeSelf &&Input.GetKeyDown(KeyCode.Escape) && playerInRange){
            dialogBox.SetActive(false);
        }
    }
    public void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Player")) {
            Debug.Log("Player entered");
            playerInRange = true;
        }
    }
    public void OnTriggerExit2D(Collider2D other) {
        if (other.CompareTag("Player")) {
            if (dialogActive) {
                dialogBox.SetActive(false);
            }
            Debug.Log("Player left");
            playerInRange = false;
        }
    }
    
}
