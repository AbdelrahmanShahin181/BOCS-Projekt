using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPCQuizTrigger : MonoBehaviour
{
    [Header("Ink JSON")]
    private GameObject dialogPanel;
    [SerializeField] private TextAsset inkJSON;
    [SerializeField] private SO_Position position;

    public bool inRange;
    public int QuizNum;
    public int correctChoice;
    public bool dialogActive = false;
    public GameObject dialogBox;
    public Text dialogText;

    public void Awake(){
        dialogPanel = NPCQuizManager.GetInstance().dialogPanel;
        inRange = false;
    }

    public void Update(){

        if(inRange /*&& !NPCQuizManager.GetInstance().activeSelf*/){

            if(Input.GetKeyDown(KeyCode.E)){
                if(position.Questions[QuizNum-1] && !dialogPanel.activeSelf) {
                    if(dialogBox.activeInHierarchy && dialogActive)
                    {
                        dialogActive = false;
                        dialogBox.SetActive(false);
                    }
                    else
                    {
                        dialogActive = true;
                        dialogBox.SetActive(true);
                        dialogText.text = "Danke, aber du hast mir bereits all meine Fragen beantwortet.";
                    }
                }
                else {
                    NPCQuizManager.GetInstance().StartDialog(inkJSON, correctChoice, QuizNum-1);
                    Debug.Log(QuizNum);
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {

        if(other.gameObject.tag == "Player"){

            inRange = true;
        }
        
    }

    private void OnTriggerExit2D(Collider2D other) {

        if(other.gameObject.tag == "Player"){
            if (dialogActive) {
                dialogBox.SetActive(false);
            }
            inRange = false;
            NPCQuizManager.GetInstance().ExitDialogeMode();
        }
        
    }
}
