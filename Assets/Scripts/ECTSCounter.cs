using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ECTSCounter : MonoBehaviour
{
    public int wert = 0;
    public Text text;

    public void erhoereWert(int value) {
        wert += value;
        text.text = "ECTS: " + wert.ToString();      
    }
}
