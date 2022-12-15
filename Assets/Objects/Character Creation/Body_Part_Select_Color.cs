using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Body_Part_Select_Color : MonoBehaviour

{
    [SerializeField] private SO_CharacterColors characterColor;
    [SerializeField] public GameObject player;
    public int bodyPart = -1;
    public string[] colors = new string[] {"_ColorHair", "_ColorSkin", "_ColorShirt", "_ColorPants"};
    private Slider red;
    private Slider green;
    private Slider blue;

    public void Start() {
        red = transform.parent.Find("Red").gameObject.GetComponent<Slider>();
        green = transform.parent.Find("Green").gameObject.GetComponent<Slider>();
        blue = transform.parent.Find("Blue").gameObject.GetComponent<Slider>();
    }

    public void ShowColor(int bodyPartIndex) {
        bodyPart = bodyPartIndex;
        UnityEngine.Color currentColor = player.transform.GetChild(bodyPartIndex).GetComponent<SpriteRenderer>().material.GetColor(colors[bodyPartIndex]);
        //Debug.Log(currentColor.r);
        red.value = currentColor.r;
        green.value = currentColor.g;
        blue.value = currentColor.b;
        
    }

    public void ChangeColor() {
        if (bodyPart != -1) {
            UnityEngine.Color newColor = new UnityEngine.Color(red.value, green.value, blue.value, 1);
            characterColor.Colors[bodyPart]= newColor;
            player.transform.GetChild(0).GetComponent<SpriteRenderer>().material.SetColor(colors[bodyPart], newColor);
            player.transform.GetChild(1).GetComponent<SpriteRenderer>().material.SetColor(colors[bodyPart], newColor);
            player.transform.GetChild(2).GetComponent<SpriteRenderer>().material.SetColor(colors[bodyPart], newColor);
            player.transform.GetChild(3).GetComponent<SpriteRenderer>().material.SetColor(colors[bodyPart], newColor);
        }
    }
}
