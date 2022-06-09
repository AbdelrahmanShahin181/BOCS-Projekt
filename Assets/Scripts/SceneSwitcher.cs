using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
   public void playGame(){
       SceneManager.LoadScene(2);
   }
   public void goToMenu(){
       SceneManager.LoadScene(1);
   }
   public void back(){
       SceneManager.LoadScene(1);
   }
}
