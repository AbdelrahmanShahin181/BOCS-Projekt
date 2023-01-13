using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ECTSCounter : MonoBehaviour
{
    public int wert = 0;
    public Text text;

    public void erhoeheWert(int value) {
        wert += value;
        text.text = wert.ToString();      
    }

    public void senkeWert(int value) {
        wert -= value;
        text.text = wert.ToString();      
    }

}
