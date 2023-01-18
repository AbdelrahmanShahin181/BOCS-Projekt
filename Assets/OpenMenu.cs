using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenMenu : MonoBehaviour
{
    public GameObject Panel;
    public GameObject Dialog;
    public GameObject Menu;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape) && !Panel.activeSelf && !Dialog.activeSelf) {
            Menu.SetActive(!Menu.activeSelf);
        }
    }
}
