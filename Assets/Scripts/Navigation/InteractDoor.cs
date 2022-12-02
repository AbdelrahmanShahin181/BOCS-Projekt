using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractDoor : MonoBehaviour

{
    //[SerializeField] private Transform cameraTransform;

    private void Update() {
        if (Input.GetKeyDown(KeyCode.E)) {
            float interactRadius = 1f;
            //private Transform transform = cameraTransform;
            //cameraTransform.position = cameraTransform.position + new Vector3 (0, 0, -10);
            //Debug.Log("Test");
            //Vector3 pos = NetworkManager.Singleton.NetworkConfig.PlayerPrefab.transform.position;
            Vector3 pos = GameObject.FindGameObjectWithTag("Player").transform.position;
            Debug.Log(pos);
            //Debug.Log(cameraTransform.position);
            Collider2D[] collider2DArray = Physics2D.OverlapCircleAll(/*cameraTransform.position*/pos, interactRadius);
            foreach (Collider2D collider2D in collider2DArray) {
                IDoor door = collider2D.GetComponent<IDoor>();
                if (door != null) {
                    door.ToggleDoor();
                }
            }
        }
    }
}