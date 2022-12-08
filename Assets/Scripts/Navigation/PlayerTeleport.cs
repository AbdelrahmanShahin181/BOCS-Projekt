using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTeleport : MonoBehaviour
{
    public GameObject menu;
    public GameObject karte;
    private GameObject currentElevator;
    
    private int layer = 0;

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
            if(Input.GetKey(KeyCode.A)) {
                ChangeLayer(layer+1);
            }
        }
        if (collision.CompareTag("StairsUp-D")) {
            if(Input.GetKey(KeyCode.D)) {
                ChangeLayer(layer+1);
            }
        }
        if (collision.CompareTag("StairsUp-W")) {
            if(Input.GetKey(KeyCode.W)) {
                ChangeLayer(layer+1);
            }
        }
        if (collision.CompareTag("StairsUp-S")) {
            if(Input.GetKey(KeyCode.S)) {
                ChangeLayer(layer+1);
            }
        }
        if (collision.CompareTag("StairsDown-A")) {
            if(Input.GetKey(KeyCode.A)) {
                ChangeLayer(layer-1);
            }
        }
        if (collision.CompareTag("StairsDown-D")) {
            if(Input.GetKey(KeyCode.D)) {
                ChangeLayer(layer-1);
            }
        }
        if (collision.CompareTag("StairsDown-W")) {
            if(Input.GetKey(KeyCode.W)) {
                ChangeLayer(layer-1);
            }
        }
        if (collision.CompareTag("StairsDown-S")) {
            if(Input.GetKey(KeyCode.S)) {
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
        GetComponent<SpriteRenderer>().sortingLayerName = target + "_Def";

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
