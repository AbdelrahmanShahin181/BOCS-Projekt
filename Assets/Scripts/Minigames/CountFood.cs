using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System.Threading;

public class CountFood : MonoBehaviour
{
    public TextMeshProUGUI score;
    public TextMeshProUGUI timer;
    public int goal = 10;
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
        timer.text = gameTime.ToString("F2");
        if (gameTime <= 0.0f) {
            gameEnded();
        }

        if(Input.GetKeyDown(KeyCode.E) && WinLose.gameObject.activeSelf) {
            SceneManager.LoadScene("Main Scene");
        }
    }

    void gameEnded(){
        if ( foodCount >= goal) {
            score.gameObject.SetActive(false);
            timer.gameObject.SetActive(false);
            WinLose.gameObject.SetActive(true);
            winLoseText.text = "Erfolg";
            //sleep for 5 seconds
            if(timeline.level == 1)
                timeline.level = 2;
            string[] text = {"Wow, so viel Essen hat noch niemand bisher gestapelt. Dafür erhältst Du einen Ehrenpreis vom AKAFÖ und wirst sofort ins zweite Semester versetzt!",
            "Und da steht gleich im H9 die Mathe 2 Vorlesung an. Die ist nicht ganz einfach, also sollte man da wirklich aufpassen."};
            timeline.endMinigameText(text);
        }
        else {
            score.gameObject.SetActive(false);
            WinLose.gameObject.SetActive(true);
            winLoseText.text = "Niederlage";
            position.hp = 2;
            position.x = 13.5f;
            position.y = -32f;
            position.layer = 0;
            string[] text = {"Das war zu wenig Essen. Du fällst in Ohnmacht und wachst geschwächt neben dem Kaffeeautomaten in der Lounge wieder auf."};
            timeline.endMinigameText(text);
            timer.gameObject.SetActive(false);
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
