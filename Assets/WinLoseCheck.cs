using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class WinLoseCheck : MonoBehaviour
{
    public TextMeshProUGUI timer;
    public GameObject inputs;
    public float targetTime = 10.0f;
    private bool won = true;
    [SerializeField] private SO_Position position;
     public Timeline timeline;
     public GameObject WinLose;
     public TextMeshProUGUI winLoseText;
    // Start is called before the first frame update
    void Start()
    {
        timeline = GameObject.Find("Timeline").GetComponent<Timeline>();
    }

    // Update is called once per frame
    void Update()
    {
        if (targetTime > 0.0f) {
            targetTime -= Time.deltaTime;
            timer.text = targetTime.ToString("F2");
        }
        else {
            for(int i = 0; i<4; i++) {
                if(!inputs.transform.GetChild(i).transform.GetChild(2).gameObject.activeSelf){
                    won = false;
                    Debug.Log("Verloren!");
                }
            }
            if(won) {
                WinLose.gameObject.SetActive(true);
                winLoseText.text = "Erfolg";
                if(timeline.level == 4)
                    timeline.level = 5;
                string[] text = {"Das war knapp, hat aber gerade noch so gereicht. Als Dankeschön nutze ich meinen Zugriff zum Mainframe der Hochschule und versetze dich ins vierte Semester.","Da muss ich eh noch mal dran, ich habe kürzlich einen Hackerangriff bemerkt...","Frag doch mal beim Infopoint nach, ob die etwas dazu wissen!"};
                timeline.endMinigameText(text);
            }
            else {
                WinLose.gameObject.SetActive(true);
                winLoseText.text = "Niederlage";
                position.hp = 2;
                position.x = 13.5f;
                position.y = -32f;
                position.layer = 0;
                string[] text = {"Verdammt, da warst Du zu langsam. Der Mitarbeiter reißt dir hektisch den Microcontroller aus der Hand und stößt dich dabei vom Stuhl.","Als du wieder zu dir kommst liegst du benommen neben dem Kaffeautomaten in der Lounge."};
                timeline.endMinigameText(text);
            }
            timer.text="0.00";
            if(Input.GetKeyDown(KeyCode.E)) {
                SceneManager.LoadScene("Main Scene");
            }
        }
    }
}
