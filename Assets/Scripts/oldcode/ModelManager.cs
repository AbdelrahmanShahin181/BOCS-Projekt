using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ModelManager : MonoBehaviour
{
   public GameObject Modelwindow;
   public TextMeshProUGUI header;
   public TextMeshProUGUI body;
   public static ModelManager Instance;

    private void Awake() {
        Instance = this;
    }
    // private void Awake()
    // {
    //      if (Instance == null)
    //      {
    //          Instance = this;
    //      }
    //      else
    //      {
    //          Destroy(gameObject);
    //      }
    // }

    public void ShowModelWindow(string header, string body)
    {
        Modelwindow.SetActive(true);
        this.header.text = header;
        this.body.text = body;
    }

    public void CloseModelWindow()
    {
        Modelwindow.SetActive(false);
    }
}
