using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeLayerScript_L_R : MonoBehaviour
{
    [SerializeField] GameObject _karte;
    [SerializeField] GameObject _karte2nd;
    [SerializeField] GameObject _colliders;
    [SerializeField] GameObject _colliders2nd;

    void OnTriggerExit2D(Collider2D pl) {
        if(pl.tag == "Player") {
        Debug.Log("Trigger");
            if(Input.GetKey(KeyCode.D)) {
                _karte2nd.SetActive(true);
                _colliders2nd.SetActive(true);
                _colliders.SetActive(false);
    
                pl.GetComponent<SpriteRenderer>().sortingLayerName = "2ndFloor";
            }
            if(Input.GetKey(KeyCode.A)) {
                _colliders2nd.SetActive(false);
                _karte2nd.SetActive(false);
                _colliders.SetActive(true);
                
                pl.GetComponent<SpriteRenderer>().sortingLayerName = "Default";
            }
        }
    }
}
