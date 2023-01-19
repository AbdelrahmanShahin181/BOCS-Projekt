using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class Snake : MonoBehaviour
{
    private Vector2 direction = Vector2.right;
    private List<Transform> _segments = new List<Transform>();
    public Transform segmentPrefab;
    public int initialSize = 3;
    private bool die = false;

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highScoreText;
    public int goal = 10;

    public GameOverScreen gameOverScreen;
    public WonScreen wonScreen ;

    private Timeline timeline;

    private int _score = 0;
    private int highScore = 0;

    [SerializeField] private SO_Position position;
    
    
    void Start()
    {
        timeline = GameObject.Find("Timeline").GetComponent<Timeline>();
        ResetState();
        highScore = PlayerPrefs.GetInt("HighScore",0);
        scoreText.text = _score.ToString() + " POINTS";
        highScoreText.text = "HIGHSCORE: " + highScore.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if(direction.x !=0){
        if(Input.GetKeyDown(KeyCode.W)){
            direction = Vector2.up;
        }
        else if(Input.GetKeyDown(KeyCode.S)){
            direction = Vector2.down;
        }
        }
        else if(direction.y !=0){
        if(Input.GetKeyDown(KeyCode.A)){
            direction =Vector2.left;
        }
       else  if(Input.GetKeyDown(KeyCode.D)){
            direction = Vector2.right;
        }
        }

        
    }
    private void FixedUpdate() {
        if(!die){
        for(int i = _segments.Count-1;i>0;i--){
            _segments[i].position = _segments[i-1].position;
        }
        transform.position = new Vector3(Mathf.Round(transform.position.x)+direction.x,Mathf.Round(transform.position.y)+direction.y,0.0f);
        }
    }
    private void Grow(){
        Transform segment = Instantiate(segmentPrefab);
        segment.position = _segments[_segments.Count-1].position;
        _segments.Add(segment);
        _score++;
        //scoreText.text = "Score: " + _score.ToString();
        scoreText.text = _score.ToString() + " POINTS";

        if(_score > highScore){
            highScore = _score;
        highScoreText.text = "HIGHSCORE: " + highScore.ToString();
            PlayerPrefs.SetInt("HighScore",highScore);
        }
    }
    private void ResetState(){
      for (int i = 1; i < _segments.Count; i++) {
            Destroy(_segments[i].gameObject);
        }
        _segments.Clear();
        _segments.Add(transform);
        for (int i = 1; i < initialSize; i++) {
            _segments.Add(Instantiate(segmentPrefab));
        }
        transform.position = Vector3.zero;
        scoreText.text = 0    + " POINTS";

        

    }



    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Food"){
            Grow();
            wonGame();
           

        }
        else if(other.tag == "Obstacle"){
            //ResetState();
            die = true;
            Debug.Log("Game Over");
            Debug.Log("Score: "+_score);
            gameOverScreen.setUp(_score);
            _score = 0;
            position.hp = 2;
            position.x = 13.5f;
            position.y = -32f;
            position.layer = 0;
            string[] text = {"Hey, du in der letzten Reihe. Aufpassen!"};
            timeline.endMinigameText(text);
            SceneManager.LoadScene("Main Scene");
        }
        else if(other.tag == "Player"){
            die = true;
            Debug.Log("Game Over");
            Debug.Log("Score: "+_score);
            gameOverScreen.setUp(_score);
            _score = 0;
            position.hp = 2;
            position.x = 13.5f;
            position.y = -32f;
            position.layer = 0;
            string[] text = {"Hey, du in der letzten Reihe. Aufpassen!"};
            timeline.endMinigameText(text);
            SceneManager.LoadScene("Main Scene");
        }

    

    }
    public void RestratGame(){
        die = false;
        gameOverScreen.gameObject.SetActive(false);
        wonScreen.gameObject.SetActive(false);
        ResetState();
        highScore = PlayerPrefs.GetInt("HighScore",0);
        scoreText.text = _score.ToString() + " POINTS";
        highScoreText.text = "HIGHSCORE: " + highScore.ToString();
        

    }
    public void wonGame(){
       if (_score >= goal){
           die = true;
            //wonGame.gameObject.SetActive(true);    
            wonScreen.setUp(_score);
            _score = 0;
            if(timeline.level == 2)
                timeline.level = 3;
            string[] text ={"Oh wow. Es ist zwar nicht ok während der Vorlesug Snake zu spielen, aber das ist ein neuer Hochschulrekord.",
            "Ich werde mal mit dem Dekan reden. Dafür wird er dich sicherlich ins dritte Semester versetzen.",
            "Frag mal an der Information wie es jetzt für dich weitergehen könnte."};
            timeline.endMinigameText(text);
            SceneManager.LoadScene("Main Scene");
           
       }
       
    }
}
