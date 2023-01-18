using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OpenEditor : MonoBehaviour
{
    // Start is called before the first frame update
    public void OpenEditorS()
    {
        SceneManager.LoadScene("CharacterCustomization");
    }

}
