using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class PositionHandler : MonoBehaviour
{
    public List<CarLapCounter> carLapCounters = new List<CarLapCounter>();
    GameObject rasultScreenWon;
    GameObject rasultScreenLost;
    bool winnerDeclared = false;

    

    // Start is called before the first frame update
    void Start()
    {
        CarLapCounter[] carLapCountersArray = FindObjectsOfType<CarLapCounter>();

        carLapCounters = carLapCountersArray.ToList<CarLapCounter>();

        foreach (CarLapCounter carLapCounter in carLapCounters) {
            carLapCounter.OnPassCheckPoint += OnPassCheckPoint;
        }

        rasultScreenWon = GameObject.Find("ResultScreenWon");
        rasultScreenLost = GameObject.Find("ResultScreenLost");
        rasultScreenWon.SetActive(false);
        rasultScreenLost.SetActive(false);
    }

    void OnPassCheckPoint(CarLapCounter carLapCounter) {
        carLapCounters = carLapCounters.OrderByDescending(x => x.GetNumberOfCheckPointsPassed()).ThenBy(x => x.GetTimeAtLastCheckPoint()).ToList();
        int carPosition = carLapCounters.IndexOf(carLapCounter) + 1;
        Debug.Log("Car Position: " + carPosition+" Car Name: "+carLapCounter.name);
        carLapCounter.SetCarPosition(carPosition);
    }

    public GameObject getRasultScreenWon() {
        return rasultScreenWon;
    }
    public GameObject getRasultScreenLost() {
        return rasultScreenLost;
    }
    public bool getWinnerDeclared() {
        return winnerDeclared;
    }
    public void setWinnerDeclared(bool winnerDeclared) {
        this.winnerDeclared = winnerDeclared;
    }
    
}
