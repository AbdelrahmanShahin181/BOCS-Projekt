using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D pl) {
        if (pl.CompareTag("Player")){
            transform.GetChild(0).gameObject.SetActive(true);
        }
    }
    private void OnTriggerExit2D(Collider2D pl) {
        if (pl.CompareTag("Player")){
            transform.GetChild(0).gameObject.SetActive(false);
        }
    }
}
