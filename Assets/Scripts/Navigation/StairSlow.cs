using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StairSlow : MonoBehaviour
{
     private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Stair")) {
            GetComponent<PlayerController>().speed = GetComponent<PlayerController>().speed/2;
        }
    }

    private void OnTriggerExit2D(Collider2D collision) {
        if (collision.CompareTag("Stair")) {
            GetComponent<PlayerController>().speed = GetComponent<PlayerController>().speed*2;
        }
    }
}
