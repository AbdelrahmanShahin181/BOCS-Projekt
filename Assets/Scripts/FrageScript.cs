using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class FrageScript : MonoBehaviour
{

    public TextMeshPro frage;
    public TextMeshPro antwort1;
    public TextMeshPro antwort2;
    public TextMeshPro antwort3;
    public TextMeshPro antwort4;


    // Start is called before the first frame update
    void Start()
    {
        frage.text =  "Hallo Ich bin Abdo ";
        antwort1.text= "A";
        antwort2.text= "B";
        antwort3.text= "C";
        antwort4.text= "D";
    }

    public void printhallo (){
        print("Hallo");
    }
}
