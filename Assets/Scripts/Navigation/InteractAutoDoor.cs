using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractAutoDoor : MonoBehaviour
{
    [SerializeField] private GameObject doorGameObject;
private IDoor door;

private void Awake() {
    door = doorGameObject.GetComponent<IDoor>();
}

   private void OnTriggerEnter2D(Collider2D pl) {
    if(pl.tag == "Player") {
        door.OpenDoor();
    }
   }

   private void OnTriggerExit2D(Collider2D pl) {
    if(pl.tag == "Player") {
        door.CloseDoor();
    
    }}
}
