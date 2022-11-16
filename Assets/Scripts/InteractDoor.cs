using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractDoor : MonoBehaviour

{
    [SerializeField] private Transform cameraTransform;

    private void Update() {
        if (Input.GetKeyDown(KeyCode.E)) {
            float interactRadius = 1f;
            //private Transform transform = cameraTransform;
            cameraTransform.position = cameraTransform.position + new Vector3 (0, 0, -10);
            //Debug.Log("Test");
            Collider2D[] collider2DArray = Physics2D.OverlapCircleAll(cameraTransform.position, interactRadius);
            foreach (Collider2D collider2D in collider2DArray) {
                IDoor door = collider2D.GetComponent<IDoor>();
                if (door != null) {
                    door.ToggleDoor();
                }
            }
        }
    }
}