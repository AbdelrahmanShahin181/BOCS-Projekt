using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetSave : MonoBehaviour
{

    [SerializeField] private SO_Position position;
    // Start is called before the first frame update
    void Start() {
        
    }
    public void Reset() {
        string[] temp ={"Das Spiel beginnt. Mit [E] kannst du im Dialog fortfahren"};
        Timeline timeline = GameObject.Find("Timeline").GetComponent<Timeline>();
        timeline.endMinigameText(temp);
        timeline.i = 0;
        timeline.textActive = true;

        GameObject.FindWithTag("Player").GetComponent<PlayerController>().Reset();
        
        if(GameObject.FindWithTag("Network Manager") != null) {
            GameObject[] NetworkManagers = GameObject.FindGameObjectsWithTag("Network Manager");
            for (int i = 0; i< NetworkManagers.Length; i++) {
                Destroy(NetworkManagers[i]);
            }
        }
        if(GameObject.FindWithTag("Player") != null) {
            Destroy(GameObject.FindWithTag("Player").gameObject);
        }
        if(GameObject.FindWithTag("Multiplayer") != null) {
            GameObject[] OtherPlayers = GameObject.FindGameObjectsWithTag("Multiplayer");
            for (int i = 0; i< OtherPlayers.Length; i++) {
                Destroy(OtherPlayers[i]);
            }
        }
        if(GameObject.Find("Timeline") != null) {
            Destroy(GameObject.Find("Timeline").gameObject);
        }
        if(GameObject.Find("Chat") != null) {
            Destroy(GameObject.Find("Chat").gameObject);
        }
        position.TimelineLevel = 0;
        position.hp = 10;
        position.kaffeeCoins = 0;
        position.x = 6.0f;
        position.y = -90.5f;
        position.layer = 0;
        for(int i = 0; i < position.Questions.Length; i++) {
            position.Questions[i] = false;
        }
        SceneManager.LoadScene("Intro");
    }
}
