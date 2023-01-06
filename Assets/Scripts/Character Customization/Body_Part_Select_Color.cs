using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Body_Part_Select_Color : MonoBehaviour

{
    [SerializeField] private SO_CharacterColors characterColor;
    [SerializeField] public GameObject player;
    public int bodyPart = -1;
    public string[] colors = new string[] {"_CHair", "_CSkin", "_CShirt", "_CPants"};
    private string[] texts = new string[] {"Haarfarbe", "Hautfarbe", "Shirtfarbe", "Hosenfarbe"};
    private Slider red;
    private Slider green;
    private Slider blue;
    private TextMeshProUGUI text;

    public void Start() {
        red = transform.parent.Find("Red").gameObject.GetComponent<Slider>();
        green = transform.parent.Find("Green").gameObject.GetComponent<Slider>();
        blue = transform.parent.Find("Blue").gameObject.GetComponent<Slider>();
        text = transform.parent.Find("Color").gameObject.GetComponent<TextMeshProUGUI>();
    }

    public void ShowColor(int bodyPartIndex) {
        bodyPart = bodyPartIndex;
        UnityEngine.Color currentColor = 
            player.transform.GetComponent<SpriteRenderer>().material.GetColor(colors[bodyPartIndex]);
        red.value = currentColor.r;
        green.value = currentColor.g;
        blue.value = currentColor.b;
    }

    public void ChangeColor() {
        if (bodyPart != -1) {
            UnityEngine.Color newColor = new UnityEngine.Color(red.value, green.value, blue.value, 1);
            characterColor.Colors[bodyPart]= newColor;
            player.transform.GetComponent<SpriteRenderer>().material.SetColor(colors[bodyPart], newColor);
            text.text = texts[bodyPart];
        }
    }
}
