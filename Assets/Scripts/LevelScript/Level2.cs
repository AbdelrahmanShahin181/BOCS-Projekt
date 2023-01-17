using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Unity.Netcode;
using Unity.Netcode.Transports.UTP;

public class Level2 : MonoBehaviour
{
   public GameObject dialogBox;
    public Text dialogText;
    public string[] dialog;
    public string[] dialogWrong;
    public bool playerInRange;
    public HealthManager healthManager;
    public HealthBarScript healthBarScript;
    public Timeline timeline;
    [SerializeField] private SO_Position position;
    public GameObject player;
    public bool dialogActive = false;

    private int counter = 0;
    
    private void Start() {
        timeline = GameObject.Find("Timeline").GetComponent<Timeline>();
        player = NetworkManager.Singleton.NetworkConfig.PlayerPrefab;
    }
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E) && playerInRange)
        {
            
            if(timeline.level >= 2){
                if(dialogBox.activeInHierarchy && dialogActive)
                {
                
                    if(counter >= dialog.Length)
                    {
                        dialogActive = false;
                        dialogBox.SetActive(false);
                        counter = 0;
                        
                        position.x = player.transform.position.x;
                        position.y = player.transform.position.y;
                        position.layer = player.transform.GetComponent<PlayerLayerControl>().layer;
                        SceneManager.LoadScene("Snake");
                    }
                    else
                    {
                        dialogText.text = dialog[counter];
                        counter++;
                    }
                }
                else if(!dialogBox.activeInHierarchy && !dialogActive)
                {
                    dialogActive = true;
                    dialogBox.SetActive(true);
                    dialogText.text = dialog[0];
                    counter = 1;
                }
            }
            else {
                if(dialogBox.activeInHierarchy && dialogActive)
                {
                
                    if(counter >= dialogWrong.Length)
                    {
                        dialogActive = false;
                        dialogBox.SetActive(false);
                        counter = 0;
                    }
                    else
                    {
                        dialogText.text = dialogWrong[counter];
                        counter++;
                    }
                }
                else if(!dialogBox.activeInHierarchy && !dialogActive)
                {
                    dialogActive = true;
                    dialogBox.SetActive(true);
                    dialogText.text = dialogWrong[0];
                    counter = 1;
                }
            }
        }
        if(dialogBox.activeSelf &&Input.GetKeyDown(KeyCode.Escape) && playerInRange){
            dialogBox.SetActive(false);
        }
    }
    public void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Player")) {
            player = other.gameObject;
            Debug.Log("Player entered");
            playerInRange = true;
        }
    }
    public void OnTriggerExit2D(Collider2D other) {
        if (other.CompareTag("Player")) {
            if (dialogActive) {
                dialogBox.SetActive(false);
                dialogActive = false;
            }
            Debug.Log("Player left");
            playerInRange = false;
        }
    }
    
}
