using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System.Threading;

public class CountFood : MonoBehaviour
{
    public TextMeshProUGUI score;
    public int foodCount = 0;
    public float gameTime = 60.0f;
    public GameObject WinLose;
    public TextMeshProUGUI winLoseText;
    public Timeline timeline;
    [SerializeField] private SO_Position position;
    // Start is called before the first frame update
    void Start()
    {
        timeline = GameObject.Find("Timeline").GetComponent<Timeline>();
        Debug.Log("Level = "+timeline.level);
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
        if ( foodCount >= 5) {
            score.gameObject.SetActive(false);
            WinLose.gameObject.SetActive(true);
            winLoseText.text = "Erfolg";
            //sleep for 5 seconds
            if(timeline.level == 1)
                timeline.level = 2;
            Thread.Sleep(5000);
            SceneManager.LoadScene("Main Scene");

        }
        else {
            score.gameObject.SetActive(false);
            WinLose.gameObject.SetActive(true);
            winLoseText.text = "Niederlage";
            if(timeline.level == 1)
                timeline.level = 1;
            Thread.Sleep(5000);
            position.hp = 2;
            position.x = 13.5;
            position.y = -32;
            SceneManager.LoadScene("Main Scene");
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
