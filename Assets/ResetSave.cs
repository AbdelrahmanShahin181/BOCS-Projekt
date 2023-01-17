using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetSave : MonoBehaviour
{

    [SerializeField] private SO_Position position;
    // Start is called before the first frame update
    public void Reset() {
        position.TimelineLevel = 0;
        position.hp = 10;
        position.kaffeeCoins = 0;
        position.x = 6.0f;
        position.y = -90.5f;
        position.layer = 0;
        for(int i = 0; i < position.Questions.Length; i++) {
            position.Questions[i] = false;
        }
        SceneManager.LoadScene("Intro");
    }
}
