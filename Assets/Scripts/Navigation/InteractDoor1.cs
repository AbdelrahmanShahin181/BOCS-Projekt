using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractDoor1 : MonoBehaviour

{
    

    private void update() {
        if (Input.GetKeyDown(KeyCode.E)) {
            Debug.Log("Test");
        }
    }
}