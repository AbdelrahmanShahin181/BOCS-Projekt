using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CountFood : MonoBehaviour
{
    public TextMeshProUGUI score;
    public int foodCount = -2;
    public float gameTime = 60.0f;
    public GameObject WinLose;
    public TextMeshProUGUI winLoseText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        gameTime -= Time.deltaTime;
        if (gameTime <= 0.0f) {
            gameEnded();
        }
    }

    void gameEnded(){
        if ( foodCount > 10) {
            score.gameObject.SetActive(false);
            WinLose.gameObject.SetActive(true);
            winLoseText.text = "Erfolg";
        }
        else {
            score.gameObject.SetActive(false);
            WinLose.gameObject.SetActive(true);
            winLoseText.text = "Niederlage";
        }
    }

    

    private void OnTriggerEnter2D(Collider2D collision){
        if (collision.CompareTag("Food")) {
            foodCount += 1;
            score.text = foodCount.ToString();
            collision.GetComponent<Rigidbody2D>().mass = collision.GetComponent<Rigidbody2D>().mass*2;
        }
    }

    private void OnTriggerExit2D(Collider2D collision){
        if (collision.CompareTag("Food")) {
            foodCount -= 1;
            score.text = foodCount.ToString();
            collision.GetComponent<Rigidbody2D>().mass = collision.GetComponent<Rigidbody2D>().mass/2;
        }
    }
}
