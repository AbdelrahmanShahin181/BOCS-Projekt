using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCQuizTrigger : MonoBehaviour
{
    [Header("Ink JSON")]
    [SerializeField] private TextAsset inkJSON;

    public bool inRange;

    public int correctChoice;

    public void Awake(){
        inRange = false;
    }

    public void Update(){

        if(inRange /*&& !NPCQuizManager.GetInstance().activeSelf*/){

            if(Input.GetKeyDown(KeyCode.E)){

                NPCQuizManager.GetInstance().StartDialog(inkJSON, correctChoice);
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

            inRange = false;
            NPCQuizManager.GetInstance().ExitDialogeMode();
        }
        
    }
}
