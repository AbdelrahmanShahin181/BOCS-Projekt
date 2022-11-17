using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoorScript : MonoBehaviour, IDoor


{
    private Animator animator;
    private bool isOpen = false;
    // Start is called before the first frame update

    private void Awake() {
        animator = GetComponent<Animator>();
    }

    public void OpenDoor() {
        isOpen = true;
        animator.SetBool("Open", true);
    }

    public void CloseDoor() {
        isOpen = false;
        animator.SetBool("Open", false);
    }

    public void ToggleDoor() {
        isOpen = !isOpen;
        if(isOpen) {
            OpenDoor();
        }
        else {
            CloseDoor();
        }
    }
}
