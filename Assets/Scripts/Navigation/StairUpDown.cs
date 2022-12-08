using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StairUpDown : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Stair")) {
            //GetComponent<RigidBody2D>().MovePosition(transform.position+ change*speed* Time.deltaTime);
        }
    }

    private void OnTriggerExit2D(Collider2D collision) {
        if (collision.CompareTag("Stair")) {
            //GetComponent<PlayerController>().speed = GetComponent<PlayerController>().speed*2;
        }
    }
}
