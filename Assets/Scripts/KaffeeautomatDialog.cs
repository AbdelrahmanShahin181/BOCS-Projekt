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
    public HealthManager healthManager;
    public HealthBarScript healthBarScript;
    public ECTSCounter ECTSCounter;
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
                    if(ECTSCounter.wert > 0) {
                        ECTSCounter.senkeWert(1);
                        healthManager.heal(5);
                        dialogText.text = "Du hast 5 Lebenspunkte wiederhergestellt!  [E] Exit";
                    }
                    else {
                        dialogText.text = "Du hast nicht genug Kaffee Coins";
                    }
                }
            }
    }
    public void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Player")) {
            Debug.Log("Player entered");
            playerInRange = true;
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