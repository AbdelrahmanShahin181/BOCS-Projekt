using System.Collections;
using System.Collections.Generic;
using System;
using Unity.Netcode;
using Unity.Netcode.Transports.UTP;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timeline : MonoBehaviour
{
    public int level = 0;
    private static GameObject instance;
    public GameObject dialogBox;
    public Text dialogText;
    public bool textActive;
    private string[] savedText = {"Das Spiel beginnt. Mit [E] kannst du im Dialog fortfahren"};
    public int i = 0;
    public int car = 0;
    [SerializeField] private SO_Position position;
    public GameObject NetworkManager;
    public string portString = "7777";
    public string ip = "127.0.0.1";

    void Start() {
        
        level = position.TimelineLevel;
        NetworkManager = FindInActiveObjectByTag("Network Manager"); 
    }

    private void OnGUI() {
        if (NetworkManager == null)
            NetworkManager = FindInActiveObjectByTag("Network Manager"); 
        if (NetworkManager != null && !NetworkManager.activeSelf) {
            GUILayout.BeginArea(new Rect(10, 10, 300, 300));
                GUILayout.Label("IP:");
                ip = GUILayout.TextField(ip);
                GUILayout.Label("Port:");
                portString = GUILayout.TextField(portString);
                if (GUILayout.Button("Start")){
                    NetworkManager.GetComponent<UnityTransport>().ConnectionData.Address = ip;
                    NetworkManager.GetComponent<UnityTransport>().ConnectionData.Port = Convert.ToUInt16(portString);
                    NetworkManager.SetActive(true);
                } 
            GUILayout.EndArea();
            
        }
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
        
        if(GameObject.Find("Spielmaske") != null){
            dialogBox = GameObject.Find("Spielmaske").transform.GetChild(3).gameObject;
            dialogText = dialogBox.transform.GetChild(0).GetComponent<UnityEngine.UI.Text>();
            textActive = true;
            dialogBox.SetActive(true);
            i = 0;
            dialogText.text = savedText[i];
        }
        //position.TimelineLevel = level;
    }
    

    public void endMinigameText(string[] text){
        savedText = text;
    }

    void Update() {
        if((Input.GetKeyUp(KeyCode.E)||Input.GetKeyUp(KeyCode.Escape)) && textActive) {
            i++;
            if (i < savedText.Length) {
                dialogText.text = savedText[i];
            }
            else{
                textActive = false;
                dialogBox.SetActive(false);
            }
        }
    }

    GameObject FindInActiveObjectByName(string name)
    {
        Transform[] objs = Resources.FindObjectsOfTypeAll<Transform>() as Transform[];
        for (int i = 0; i < objs.Length; i++)
        {
            if (objs[i].hideFlags == HideFlags.None)
            {
                Debug.Log(objs[i].name);
                if (objs[i].name == name)
                {
                    return objs[i].gameObject;
                }
            }
        }
        return null;
    }

    GameObject FindInActiveObjectByTag(string tag)
    {

        Transform[] objs = Resources.FindObjectsOfTypeAll<Transform>() as Transform[];
        for (int i = 0; i < objs.Length; i++)
        {
            if (objs[i].hideFlags == HideFlags.None)
            {
                if (objs[i].CompareTag(tag))
                {
                    return objs[i].gameObject;
                }
            }
        }
        return null;
    }
    
}
