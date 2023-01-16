using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class CarLapCounter : MonoBehaviour
{
    int passedCheckPointNumber = 0;
    float timeAtLastCheckPoint = 0;

    int numberOfPassedCheckPoints = 0;

    int lapsCompleted = 0;

    public int lapsToComplete = 1;

    bool isRaceCompleted = false;

    public int carPosition = 0;

    public bool isAI = false;

    GameObject startRaceButton;

    PositionHandler positionHandler;

    private Timeline timeline;

    [SerializeField] private SO_Position position;


    public event Action<CarLapCounter> OnPassCheckPoint;


    private void Start() {
        timeline = GameObject.Find("Timeline").GetComponent<Timeline>();
        if (startRaceButton == null){
            startRaceButton = GameObject.Find("StartRace");
            Debug.Log("StartRaceButton: " + startRaceButton);
        }
        positionHandler = FindObjectOfType<PositionHandler>();
    }

    private void Update() {
        if(Input.GetKeyDown(KeyCode.E) && (positionHandler.getRasultScreenWon().activeSelf||positionHandler.getRasultScreenLost().activeSelf)){
            SceneManager.LoadScene("Main Scene");
        }
    }

    public void SetCarPosition(int position) {
        carPosition = position;
    }

    public int GetNumberOfCheckPointsPassed() {
        return numberOfPassedCheckPoints;
    }

    public float GetTimeAtLastCheckPoint() {
        return timeAtLastCheckPoint;
    }

    void OnTriggerEnter2D(Collider2D collider2d){
        if (collider2d.CompareTag("CheckPoint")) {
            if (isRaceCompleted) {
                return;
            }

            CheckPoint checkPoint = collider2d.GetComponent<CheckPoint>();
            if (passedCheckPointNumber +1 == checkPoint.checkPointNumber){
                passedCheckPointNumber = checkPoint.checkPointNumber;
                numberOfPassedCheckPoints++;

                timeAtLastCheckPoint = Time.time;

                if (checkPoint.isFinishLine) {
                    passedCheckPointNumber = 0;
                    lapsCompleted++;
                    if (lapsCompleted >= lapsToComplete && !positionHandler.getWinnerDeclared()) {
                        isRaceCompleted = true;
                        if (!isAI) {
                            Debug.Log("You Won");
                            positionHandler.getRasultScreenWon().SetActive(true);
                            if(timeline.level ==3)
                                //timeline.level = 4;
                                timeline.car = 1;
                            string[] text = {"Wow, du bist wirklich ganz schön schnell. Ein Versprechen ist ein Versprechen also darfst du das Auto behalten", "Wenn du aber sowieso immer mit der U-Bahn kommst, weil du so Umweltbewusst bist, solltest du mal mit dem Dozenten in C-6 sprechen.", "Ich habe gehört der sucht ein neues Auto. Vielleicht bietet er dir ja etwas im Tausch an"};
                            timeline.endMinigameText(text);
                        }
                        else {
                            Debug.Log("You Lost"+ " Your Position: " + carPosition);
                            positionHandler.getRasultScreenLost().SetActive(true);
                            position.hp = 2;
                            position.x = -7f;
                            position.y = -103f;
                            position.layer = 0;
                            string[] text ={"Puh, Das war zum Glück nur ein Traum. Aber so ein Alptraum setzt einem auch ganz schön zu. Versuche es gleich nochmal."};
                            timeline.endMinigameText(text);
                        }
                        positionHandler.setWinnerDeclared(true);
                    }
                }

                OnPassCheckPoint?.Invoke(this);
            }
        }
    }
}
