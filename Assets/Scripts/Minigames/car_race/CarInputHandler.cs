using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarInputHandler : MonoBehaviour
{

    public bool isUIInput = false;

    Vector2 inputVector = Vector2.zero;

    // Components
    CarController carController;
    GameObject canvasInGame; 


    private void Awake() {
        carController = GetComponent<CarController>();
        canvasInGame = GameObject.Find("MoblieUICanvas");
        canvasInGame.SetActive(false);
        if (isUIInput) {
            canvasInGame.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isUIInput) {
            
        }
        else {
            inputVector = Vector2.zero;
            inputVector.x = Input.GetAxis("Horizontal");
            inputVector.y = Input.GetAxis("Vertical");
            
        }
        carController.SetInputVector(inputVector);

        
    }

    public void SetInput(Vector2 newInput) {
        this.inputVector = newInput;
    }
}
