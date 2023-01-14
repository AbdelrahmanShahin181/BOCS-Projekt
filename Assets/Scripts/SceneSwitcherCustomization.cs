using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcherCustomization : MonoBehaviour
{
   public void StartMain(){
        SceneManager.LoadScene("Main Scene");
   }
}
