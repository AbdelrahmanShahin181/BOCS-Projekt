using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timeline : MonoBehaviour
{
    public int level = 0;
    private static GameObject instance;
    public GameObject dialogBox;
    public Text dialogText;
    private bool textActive;
    private string savedText = "Das Spiel beginnt";

    private void Awake() {
        DontDestroyOnLoad(this.gameObject);
        if (instance == null) {
            instance = gameObject;
            SceneManager.sceneLoaded += OnSceneLoaded;
        }
        else
            Destroy(gameObject);
        
        
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode) {
        dialogBox = GameObject.Find("Spielmaske").transform.GetChild(3).gameObject;
        dialogText = dialogBox.transform.GetChild(0).GetComponent<UnityEngine.UI.Text>();
        textActive = true;
        dialogBox.SetActive(true);
        dialogText.text = savedText;
    }
    

    public void endMinigameText(string text){
        savedText = text;
    }

    void Update() {
        if((Input.GetKeyDown(KeyCode.E)||Input.GetKeyDown(KeyCode.Escape)) && textActive) {
            textActive = false;
            dialogBox.SetActive(false);
        }
    }
    
}
