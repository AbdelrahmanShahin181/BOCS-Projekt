//using System.Collections;
using System;
//using System.Collections.Generic;
using UnityEngine;

public class PlayerLayerControl : MonoBehaviour
{
    public GameObject menu;
    public GameObject karte;
    private GameObject currentElevator;
    
    public int layer = 0;

    public void Start() {
        karte = GameObject.Find("Karte");
        menu = GameObject.Find("Spielmaske").transform.GetChild(0).gameObject;
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)) {
            if (currentElevator != null) {
                //transform.position = currentElevator.GetComponent<ElevatorTeleport>().GetDestination().position;
                menu.SetActive(!menu.activeSelf);
                
            }
            
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Elevator")) {
            currentElevator = collision.gameObject;
        }
    }

    private void OnTriggerExit2D(Collider2D collision) {
        if (collision.CompareTag("Elevator")) {
            if (collision.gameObject == currentElevator) {
                currentElevator = null;
                menu.SetActive(false);
            }
        }
        if (collision.CompareTag("StairsUp-A")) {
            if(collision.transform.position.x > transform.position.x) {
                ChangeLayer(layer+1);
            }
        }
        if (collision.CompareTag("StairsUp-D")) {
            if(collision.transform.position.x < transform.position.x) {
                ChangeLayer(layer+1);
            }
        }
        if (collision.CompareTag("StairsUp-W")) {
            if(collision.transform.position.y < transform.position.y) {
                ChangeLayer(layer+1);
            }
        }
        if (collision.CompareTag("StairsUp-S")) {
            if(collision.transform.position.y > transform.position.y) {
                ChangeLayer(layer+1);
            }
        }
        if (collision.CompareTag("StairsDown-A")) {
            if(collision.transform.position.x > transform.position.x) {
                ChangeLayer(layer-1);
            }
        }
        if (collision.CompareTag("StairsDown-D")) {
            if(collision.transform.position.x < transform.position.x) {
                ChangeLayer(layer-1);
            }
        }
        if (collision.CompareTag("StairsDown-W")) {
            if(collision.transform.position.y < transform.position.y) {
                ChangeLayer(layer-1);
            }
        }
        if (collision.CompareTag("StairsDown-S")) {
            if(collision.transform.position.y > transform.position.y) {
                ChangeLayer(layer-1);
            }
        }
    }

    public void ChangeLayer(int target){
        for(int i = 0; i<target+1; i++) {
            karte.transform.GetChild(i).transform.GetChild(2).gameObject.SetActive(true);
            karte.transform.GetChild(i).transform.GetChild(1).gameObject.SetActive(false);
            karte.transform.GetChild(i).transform.GetChild(0).gameObject.SetActive(false);
            
        }

        karte.transform.GetChild(target+1).transform.GetChild(2).gameObject.SetActive(true);
        karte.transform.GetChild(target+1).transform.GetChild(1).gameObject.SetActive(true);
        karte.transform.GetChild(target+1).transform.GetChild(0).gameObject.SetActive(true);
        try {
            Transform cStairsUp = karte.transform.GetChild(target+1).Find("Triggers").Find("Navigation").Find("Stairs").Find("StairC").Find("Up");
            Transform cStairsDown = karte.transform.GetChild(target+1).Find("Triggers").Find("Navigation").Find("Stairs").Find("StairC").Find("Down");
            if(cStairsUp != null && cStairsDown != null){
                if(target<layer){
                    cStairsUp.gameObject.SetActive(true);
                    cStairsDown.gameObject.SetActive(false);
                }
                else {
                    cStairsUp.gameObject.SetActive(false);
                    cStairsDown.gameObject.SetActive(true);
                }
            }
        }
        catch(NullReferenceException e){}
        transform.GetComponent<SpriteRenderer>().sortingLayerName = target + "_Def";

        for(int i = target+2; i<9; i++) {
            karte.transform.GetChild(i).transform.GetChild(2).gameObject.SetActive(false);
            karte.transform.GetChild(i).transform.GetChild(1).gameObject.SetActive(false);
            karte.transform.GetChild(i).transform.GetChild(0).gameObject.SetActive(false);
        }

        layer = target;
    }

    public void Teleport(int target){
        if (currentElevator != null) {
                transform.position = transform.position + new Vector3(0, (target-layer)*2, 0);
                ChangeLayer(target);
            }
    }
}
