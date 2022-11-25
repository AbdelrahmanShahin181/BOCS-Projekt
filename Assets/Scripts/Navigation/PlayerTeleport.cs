using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTeleport : MonoBehaviour
{
    private GameObject currentElevator;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)) {
            if (currentElevator != null) {
                transform.position = currentElevator.GetComponent<ElevatorTeleport>().GetDestination().position;
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
            }
        }
    }
}
