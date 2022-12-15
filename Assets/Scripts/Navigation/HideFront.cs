using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideFront : MonoBehaviour
{
    public float minSize;
    public float maxSize;
    public float minStrength;
    public float maxStrength;
    public float fadeTime;
    private float fadeTimer;
    private bool inOut = true;

    void Start(){
        fadeTimer = fadeTime;
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Player")) {
            inOut=false;
            fadeTimer = fadeTime;
            /*transform.GetChild(0).gameObject.SetActive(false);
            transform.GetChild(1).gameObject.SetActive(false);
            transform.GetChild(2).gameObject.SetActive(false);*/
        }
    }

    private void OnTriggerExit2D(Collider2D collision) {
        if (collision.CompareTag("Player")) {
            inOut=true;
            fadeTimer = fadeTime;
            /*transform.GetChild(0).gameObject.SetActive(true);
            transform.GetChild(1).gameObject.SetActive(true);
            transform.GetChild(2).gameObject.SetActive(true);*/
        }
    }

    void Update(){
        if(fadeTimer > 0){
            fadeTimer -= Time.deltaTime;
            if(fadeTimer < 0) {
                    fadeTimer = 0;
                }
            float spanDist = maxSize-minSize;
            float spanStren = maxStrength-minStrength;
            float dist;
            float stren;
            if(inOut){
                dist = (fadeTimer/fadeTime)*spanDist+minSize;
                stren = (fadeTimer/fadeTime)*spanStren+minStrength;
            }
            else {
                dist = (1 - fadeTimer/fadeTime)*spanDist+minSize;
                stren = (1 - fadeTimer/fadeTime)*spanStren+minStrength;     
            }
            transform.GetChild(0).gameObject.GetComponent<VisibilityShaderScript>().distance = dist;
            transform.GetChild(1).gameObject.GetComponent<VisibilityShaderScript>().distance = dist;
            transform.GetChild(2).gameObject.GetComponent<VisibilityShaderScript>().distance = dist;
            transform.GetChild(0).gameObject.GetComponent<VisibilityShaderScript>().strength = stren;
            transform.GetChild(1).gameObject.GetComponent<VisibilityShaderScript>().strength = stren;
            transform.GetChild(2).gameObject.GetComponent<VisibilityShaderScript>().strength = stren;
        }
    }
}
