using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KaffeeautomatDialog : MonoBehaviour
{
    public GameObject Dialog;
    public GameObject DialogText;
    public string dialog;
    public bool isDialogActive = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "Player_Boy" || other.gameObject.tag == "Player_Girl") {
            isDialogActive = true;
            Dialog.SetActive(true);
            DialogText.GetComponent<Text>().text = dialog;
        }
    }
}
