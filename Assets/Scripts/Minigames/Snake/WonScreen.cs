using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class WonScreen : MonoBehaviour
{
    public TextMeshProUGUI scoreText;

    public void setUp(int score)
    {
        gameObject.SetActive(true);
        scoreText.text = score.ToString() + " POINTS";
    }
     public void backtoMainScreen()
    {
        gameObject.SetActive(false);
        UnityEngine.SceneManagement.SceneManager.LoadScene("MainScreen");
    }
}
