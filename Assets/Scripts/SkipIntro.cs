using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SkipIntro : MonoBehaviour
{

    [SerializeField] private SO_Position position;
    // Start is called before the first frame update
    void Start()
    {
        if (position.TimelineLevel > 0) {
            SceneManager.LoadScene("Main Scene");
        }
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Escape)) {
            SceneManager.LoadScene("CharacterCustomization");
        }
    }

}
