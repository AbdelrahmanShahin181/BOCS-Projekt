using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CarLapCounter : MonoBehaviour
{
    int passedCheckPointNumber = 0;
    float timeAtLastCheckPoint = 0;

    int numberOfPassedCheckPoints = 0;

    int lapsCompleted = 0;

    const int lapsToComplete = 2;

    bool isRaceCompleted = false;

    public int carPosition = 0;

    public bool isAI = false;

    GameObject startRaceButton;

    PositionHandler positionHandler;


    public event Action<CarLapCounter> OnPassCheckPoint;


    private void Start() {
        if (startRaceButton == null){
            startRaceButton = GameObject.Find("StartRace");
            Debug.Log("StartRaceButton: " + startRaceButton);
        }
        positionHandler = FindObjectOfType<PositionHandler>();
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
                        }
                        else {
                            Debug.Log("You Lost"+ " Your Position: " + carPosition);
                            positionHandler.getRasultScreenLost().SetActive(true);
                        }
                        positionHandler.setWinnerDeclared(true);
                    }
                }

                OnPassCheckPoint?.Invoke(this);
            }
        }
    }
}
