using System.Collections.Generic;
using UnityEngine;
using TMPro;

[System.Serializable]
public class Dialog: MonoBehaviour
{
    public string characterName;
    public string[] sentences;
    public Queue<string> sentencesQueue;
    public GameObject Modelwindow;
    public TextMeshProUGUI header;
    public TextMeshProUGUI body;

    public void ShowDialog(){   
        sentencesQueue = new Queue<string>();
        foreach(string sentence in sentences)
        {
            sentencesQueue.Enqueue(sentence);
        }
        DisplayNextSentence();

        
    }

    public void DisplayNextSentence(){
        
        if(sentencesQueue.Count==0){
            CloseModelWindow();
            return;
        }
        string sentenceText = sentencesQueue.Dequeue();
        ShowModelWindow(characterName,sentenceText);
    }

    public void ShowModelWindow(string header, string body)
    {
        Modelwindow.SetActive(true);
        this.header.text = header;
        this.body.text = body;
    }

    public void CloseModelWindow()
    {
        Modelwindow.SetActive(false);
    }
    
}

