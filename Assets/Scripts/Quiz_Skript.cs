using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Quiz_Skript : MonoBehaviour
{
    public GameObject dialogBox;
    public Text dialogText;
    public string dialog;
    public bool playerInRange;
    public HealthManager healthManager;
    public NPC_movement npc;
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

        if(Input.GetKeyDown(KeyCode.J) && playerInRange){
                if(healthManager != null){
                    healthManager.heal(5);
                    dialogText.text = ("Wie kann man in der Mensa bezahlen? \n [1] Nur Bar \n [2] Die Essenskosten sind im Semesterbeitrag enthalten \n [3] Mit der EC-Karte oder dem Studierendenausweiß. \n [E] Exit");
                }
            }
        
    }
    
    public void OnTriggerEnter2D(Collider2D other1) {
        if (other1.CompareTag("Player")) {
            Debug.Log("Player entered");
            playerInRange = true;
            healthManager = other1.GetComponent<HealthManager>();
        }
    }
    public void OnTriggerExit2D(Collider2D other1) {
        if (other1.CompareTag("Player")) {
            Debug.Log("Player left");
            playerInRange = false;
            dialogBox.SetActive(false);
        }
    }
}
