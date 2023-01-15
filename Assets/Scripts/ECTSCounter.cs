using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ECTSCounter : MonoBehaviour
{
    public int wert;
    public Text text;
    [SerializeField] private SO_Position position;

    public void Start() {
        text = GameObject.Find("Wert").GetComponent<Text> ();
        wert = position.kaffeeCoins;
        text.text = wert.ToString();
    }

    public void erhoeheWert(int value) {
        wert += value;
        text.text = wert.ToString();    
        position.kaffeeCoins = wert;  
    }

    public void senkeWert(int value) {
        wert -= value;
        text.text = wert.ToString();    
        position.kaffeeCoins = wert;  
    }

}
