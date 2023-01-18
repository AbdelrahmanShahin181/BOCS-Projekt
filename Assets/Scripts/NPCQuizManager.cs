using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Ink.Runtime;
using UnityEngine.EventSystems;
using Unity.Netcode;
using Unity.Netcode.Transports.UTP;

public class NPCQuizManager : MonoBehaviour
{
    [Header("Dialog UI")]
    public GameObject dialogPanel;
    [SerializeField] private TextMeshProUGUI dialogText;
    [SerializeField] private SO_Position position;

    [Header("Choices UI")]
    [SerializeField] private GameObject[] choices;
    private TextMeshProUGUI[] choiceTexts;
    private Story currentStory;
    public bool dialogIsActive{get; private set;}

    private static NPCQuizManager instance;
    private int rightChoice;
    private int QuizNum;

    
    HealthManager hpLoss;
    public GameObject player;

    private void Awake(){

        if(instance != null){

            Debug.LogWarning("Es gibt mehrere Dialog Manager in der Scene!");
        }

            instance = this;
    }

    public static NPCQuizManager GetInstance(){

        if(instance == null){
            //GameObject instanceObj = new GameObject("NPCQuizManager");
            //gameObject.AddComponent<NPCQuizManager>();
            //instance = instanceObj.AddComponent<NPCQuizManager>();
            //instance = dialogPanel.gameObject.AddComponent<NPCQuizManager>();
            instance = new NPCQuizManager();
        }

        return instance;
    }

    private void Start(){

        dialogIsActive = false;
        dialogPanel.SetActive(false);

        choiceTexts = new TextMeshProUGUI[choices.Length];
        int index = 0;
        foreach(GameObject choice in choices){

            choiceTexts[index] = choice.GetComponentInChildren<TextMeshProUGUI>();
            index++;
        }
    }

    private void Update(){

        if(dialogIsActive){

            if(Input.GetKeyDown(KeyCode.E)){

                ContinueStory();
            }
        }
    }

    public void StartDialog(TextAsset inkJSON, int correctChoice, int Num){
        QuizNum = Num;
        rightChoice = correctChoice;
        currentStory = new Story(inkJSON.text);
        dialogIsActive = !dialogIsActive;
        dialogPanel.SetActive(dialogIsActive);
        ContinueStory();
    }

    public void ExitDialogeMode(){

        dialogIsActive = false;
        dialogPanel.SetActive(false);
        dialogText.text = "";
    }

    private void ContinueStory(){

        if(currentStory.canContinue){

            // Setze DialogText auf den nächsten Knoten
            dialogText.text = currentStory.Continue();
            // Zeige die Choices an
            DisplayChoices();
        }

        else{

            //ExitDialogeMode();
        }
    }

    private void DisplayChoices(){

        List<Choice> currentChoices = currentStory.currentChoices;

        //Check if there are more choices than UI elements
        if(currentChoices.Count > choices.Length){

            Debug.LogWarning("Es gibt mehr Choices als UI Elemente! Es werden nur: " + currentChoices.Count + " angezeigt!");
        }

        int index = 0;

        //Display all choices
        foreach(Choice choice in currentChoices){

            choices[index].SetActive(true);
            choiceTexts[index].text = choice.text;
            index++;
        }

        // Hide all unused choices
        for(int i = index; i < choices.Length; i++){

            choices[i].SetActive(false);
        }

        StartCoroutine(SelectFirstChoice());
    }

    private IEnumerator SelectFirstChoice(){
        //Das Eventsystem muss auf null gesetzt werden, damit es nicht mehr auf das letzte UI Element zeigt
        EventSystem.current.SetSelectedGameObject(null);
        yield return new WaitForEndOfFrame();
        EventSystem.current.SetSelectedGameObject(choices[0].gameObject);
    }

    public void chooseChoice(int choiceIndex){

        currentStory.ChooseChoiceIndex(choiceIndex);

        if(choiceIndex == rightChoice){
            position.Questions[QuizNum] = true;
            AddECTS();
        }

        else{

            looseHP();
        }

        ContinueStory();
    }
    

    public void AddECTS(){

        player = GameObject.FindGameObjectWithTag("Player");
        player.GetComponent<ECTSCounter>().erhoeheWert(5);
    }

    public void looseHP(){
        hpLoss = GameObject.Find("Healthbar").GetComponent<HealthManager>();
        hpLoss.TakeDamage(2);
    }


}
