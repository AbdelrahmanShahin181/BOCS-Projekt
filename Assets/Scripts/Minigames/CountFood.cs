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
    private string text;
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

        if(Input.GetKeyDown(KeyCode.E) && WinLose.gameObject.activeSelf) {
            SceneManager.LoadScene("Main Scene");
            timeline.endMinigameText(text);
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
            text = "Du hast ganz schön viel gestapelt";
        }
        else {
            score.gameObject.SetActive(false);
            WinLose.gameObject.SetActive(true);
            winLoseText.text = "Niederlage";
            if(timeline.level == 1)
                timeline.level = 1;
            position.hp = 2;
            position.x = 13.5f;
            position.y = -32f;
            position.layer = 0;
            text = "Das war zu wenig Essen. Du fällst in Ohnmacht und wachst geschwächt neben dem Kaffeeautomaten in der Lounge wieder auf.";
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
