using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindChat : MonoBehaviour
{
    GameObject chat;
    // Start is called before the first frame update
    void Start()
    {
        chat = GameObject.Find("Chat");
    }

    // Update is called once per frame
    void OnClick()
    {
        chat.transform.GetChild(0).gameObject.SetActive(!chat.transform.GetChild(0).gameObject.activeSelf);
    }
}
