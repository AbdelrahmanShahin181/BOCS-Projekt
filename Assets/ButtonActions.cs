using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonActions : MonoBehaviour
{
    [SerializeField] private SO_Position position;
    // Start is called before the first frame update
    void Start()
    {
        //timeline = GameObject.Find("Timeline").GetComponent<Timeline>();
    }

    // Update is called once per frame
    public void Respawn() {
        string[] temp ={"Mit letzter Kraft schaffst du es zum Kaffeautomaten und kannst gerade noch so einen Kaffe kaufen. Aber pass auf, du bist geschwächt und hast nur 1 Lebenspunkt!"};
        Timeline timeline = GameObject.Find("Timeline").GetComponent<Timeline>();
        timeline.endMinigameText(temp);
        timeline.i = 0;
        timeline.textActive = true;

        //position.TimelineLevel = 0;
        position.hp = 1;
        position.kaffeeCoins = position.kaffeeCoins -1;
        if(position.kaffeeCoins < 0)
            position.kaffeeCoins = 0;
        position.x = 13.5f;
        position.y = -32f;
        position.layer = 0;
        
        SceneManager.LoadScene("Main Scene");
    }
}
