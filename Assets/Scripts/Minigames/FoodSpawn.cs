using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodSpawn : MonoBehaviour
{
    
    // Reference to the Prefab. Drag a Prefab into this field in the Inspector.
    public GameObject food0;
    public GameObject food1;
    public GameObject food2;
    public GameObject food3;
    public GameObject food4;
    
    public float targetTime = 5.0f;
    private GameObject myPrefab;
    public float timerTime;


    // This script will simply instantiate the Prefab when the game starts.
    void Start()
    {
        timerTime = targetTime;
        // Instantiate at position (0, 0, 0) and zero rotation.
        //Instantiate(myPrefab, new Vector3(10, 0, 0), Quaternion.identity);
    }

    void Update(){
    
    timerTime -= Time.deltaTime;
    
    if (timerTime <= 0.0f)
    {
        timerEnded();
    }
    
    }
    
    void timerEnded()
    {
        int whichFood = Random.Range(0, 5);
        
        switch (whichFood) {
            case 0:
                myPrefab = food0;
                break;
            case 1:
                myPrefab = food1;
                break;
            case 2:
                myPrefab = food2;
                break;
            case 3:
                myPrefab = food3;
                break;
            case 4:
                myPrefab = food4;
                break;
        }
        GameObject obj = (GameObject)Instantiate(myPrefab, new Vector3(Random.Range(-7.5f, 7.5f), 10, 0), Quaternion.Euler( 0, 0, Random.Range(-180f, 180f)));
        obj.GetComponent<Rigidbody2D>().angularVelocity = Random.Range(-150f, 150f);
        timerTime = targetTime + Random.Range(-0.3f, 1.5f);
    }
}
