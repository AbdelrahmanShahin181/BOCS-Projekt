using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public int iLevelToLoad;
    void Start()
    {
        
    }


    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision){
        GameObject collisionGameObject = collision.gameObject;
        if(collisionGameObject.name == "Player_Boy"){
            LoadScene();
        } 
    }

    void LoadScene(){
        SceneManager.LoadScene(iLevelToLoad);
    }
}
