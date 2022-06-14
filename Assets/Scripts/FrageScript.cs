using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class FrageScript : MonoBehaviour
{

    public TextMeshProUGUI frage;
    public TextMeshProUGUI antwort1;
    public TextMeshProUGUI antwort2;
    public TextMeshProUGUI antwort3;
    public TextMeshProUGUI antwort4;


    // Start is called before the first frame update
    void Start()
    {
        frage.text =  "System.out.print...()";
        antwort1.text= "line";
        antwort2.text= "lime";
        antwort3.text= "life";
        antwort4.text= "like";
    }

    public void printhallo (){
        print("Hallo");
    }
}
