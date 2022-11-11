using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeLayerScript : MonoBehaviour
{
    [SerializeField] GameObject _karte;
    [SerializeField] GameObject _karte2nd;
    [SerializeField] GameObject _colliders;
    [SerializeField] GameObject _colliders2nd;
    [SerializeField] GameObject _etageTriggerUp;
    [SerializeField] GameObject _etageTriggerDown;


    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D pl) {
        if(pl.tag == "Player") {
        //Debug.Log("Trigger");
        if(!_karte2nd.activeSelf) {
            _etageTriggerDown.SetActive(true);
            _etageTriggerUp.SetActive(false);
            _karte2nd.SetActive(true);
            _colliders.SetActive(false);
            _colliders2nd.SetActive(true);
            
            pl.GetComponent<SpriteRenderer>().sortingLayerName = "2ndFloor";
        }
        else{
            _etageTriggerDown.SetActive(false);
            _etageTriggerUp.SetActive(true);
            _karte2nd.SetActive(false);
            _colliders.SetActive(true);
            _colliders2nd.SetActive(false);

            pl.GetComponent<SpriteRenderer>().sortingLayerName = "Default";
        }
        }
    }
}
