using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCQuizTrigger : MonoBehaviour
{
    [Header("Visual Cue")]
    [SerializeField] private GameObject visualCue;

    [Header("Ink JSON")]
    [SerializeField] private TextAsset inkJSON;

    public bool inRange;

    public void Awake(){

        visualCue.SetActive(false);
        inRange = false;
    }

    public void Update(){

        if(inRange && !NPCQuizManager.GetInstance().dialogIsActive){

            visualCue.SetActive(true);

            if(Input.GetKeyDown(KeyCode.E)){

                NPCQuizManager.GetInstance().StartDialog(inkJSON);
            }
        }

        else{
                
                visualCue.SetActive(false);
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
        }
        
    }
}
