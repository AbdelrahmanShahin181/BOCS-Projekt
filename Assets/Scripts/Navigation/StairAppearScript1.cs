using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StairAppearScript1 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerExit2D(Collider2D collision) 
    {
        Debug.Log("test");
        if (collision.CompareTag("Player")) {
            
            transform.parent.GetChild(0).gameObject.SetActive(false);
            transform.parent.GetChild(1).gameObject.SetActive(true);
            
        }
    }
}
