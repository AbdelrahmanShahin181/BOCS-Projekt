using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KaffeeautomatDialog : MonoBehaviour
{
    public GameObject dialogBox;
    public Text dialogText;
    public string dialog;
    public bool playerInRange;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E) && playerInRange)
        {
            if(dialogBox.activeInHierarchy)
            {
                dialogBox.SetActive(false);
            }
            else
            {
                dialogBox.SetActive(true);
                dialogText.text = dialog;
            }
        }
    }
    
    public void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Player")) {
            Debug.Log("Player entered");
            playerInRange = true;

            if(Input.GetKeyDown(KeyCode.J)){
                var health = other.GetComponent<HealthManager>();
                health.heal(5);
            }
        }
    }
    public void OnTriggerExit2D(Collider2D other) {
        if (other.CompareTag("Player")) {
            Debug.Log("Player left");
            playerInRange = false;
            dialogBox.SetActive(false);
        }
    }
}