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
        if(GameObject.FindWithTag("Player") != null) {
            Destroy(GameObject.FindWithTag("Player").gameObject);
        }
        if(GameObject.FindWithTag("Multiplayer") != null) {
            Destroy(GameObject.FindWithTag("Multiplayer").gameObject);
        }
        if(GameObject.Find("Network Manager") != null) {
            Destroy(GameObject.Find("Network Manager").gameObject);
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
