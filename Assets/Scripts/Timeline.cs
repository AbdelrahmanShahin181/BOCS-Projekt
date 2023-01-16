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
    private string[] savedText = {"Das Spiel beginnt. Mit [E] kannst du im Dialog fortfahren"};
    private int i = 0;
    public int car = 0;
    [SerializeField] private SO_Position position;

    void Start() {
        level = position.TimelineLevel;
    }

    private void Awake() {
        DontDestroyOnLoad(this.gameObject);
        if (instance == null) {
            instance = gameObject;
            SceneManager.sceneLoaded += OnSceneLoaded;
        }
        else
            Destroy(gameObject);
    }

    private void OnApplicationQuit() {
        position.TimelineLevel = level;
        position.x = 6.0f;
        position.y = -90.5f;
        position.layer = 0;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode) {
        dialogBox = GameObject.Find("Spielmaske").transform.GetChild(3).gameObject;
        dialogText = dialogBox.transform.GetChild(0).GetComponent<UnityEngine.UI.Text>();
        textActive = true;
        dialogBox.SetActive(true);
        i = 0;
        dialogText.text = savedText[i];
        //position.TimelineLevel = level;
    }
    

    public void endMinigameText(string[] text){
        savedText = text;
    }

    void Update() {
        if((Input.GetKeyDown(KeyCode.E)||Input.GetKeyDown(KeyCode.Escape)) && textActive) {
            i++;
            if (i< savedText.Length) {
                dialogText.text = savedText[i];
            }
            else{
                textActive = false;
                dialogBox.SetActive(false);
            }
        }
    }
    
}
