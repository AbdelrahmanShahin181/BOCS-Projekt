using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ECTSPickup : MonoBehaviour
{
    public int value;

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Player")) {
            other.gameObject.GetComponent<ECTSCounter>().erhoeheWert(value);
            Destroy(gameObject);
        }
        
    }
}
