using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Unity.Netcode;
using Unity.Netcode.Transports.UTP;

public class Level1 : MonoBehaviour
{
   public GameObject dialogBox;
    public Text dialogText;
    public string[] dialog;
    public bool playerInRange;
    public HealthManager healthManager;
    public HealthBarScript healthBarScript;
    public Timeline timeline;
    [SerializeField] private SO_Position position;
    public GameObject player;

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
            
            if(dialogBox.activeInHierarchy)
            {
                if(counter >= dialog.Length)
                {
                    dialogBox.SetActive(false);
                    counter = 0;
                    if(timeline.level >= 1){
                        position.x = player.transform.position.x;
                        position.y = player.transform.position.y;
                        position.layer = player.transform.GetComponent<PlayerLayerControl>().layer;
                        SceneManager.LoadScene("MensaMiniGame");
                    }
                    
                    //Debug.Log("Level 2");
                }
                else
                {
                    dialogText.text = dialog[counter];
                    counter++;
                }
            }
            else
            {
                dialogBox.SetActive(true);
                dialogText.text = dialog[0];
                counter = 1;
            }
        }
        if(dialogBox.activeSelf &&Input.GetKeyDown(KeyCode.Escape) && playerInRange){
            dialogBox.SetActive(false);
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
