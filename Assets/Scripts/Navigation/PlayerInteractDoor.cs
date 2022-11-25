using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractDoor : MonoBehaviour
{
    private IDoor currentDoor;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)) {
            if (currentDoor != null) {
                currentDoor.ToggleDoor();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Door")) {
            currentDoor = collision.gameObject.GetComponent<IDoor>();
        }
    }

    private void OnTriggerExit2D(Collider2D collision) {
        if (collision.CompareTag("Door")) {
            if (collision.gameObject.GetComponent<IDoor>() == currentDoor) {
                currentDoor = null;
            }
        }
    }
}
