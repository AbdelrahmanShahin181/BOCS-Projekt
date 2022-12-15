using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StairAppearScript : MonoBehaviour
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
            if(collision.transform.position.y < transform.position.y) {
                transform.GetChild(0).gameObject.SetActive(true);
                transform.GetChild(1).gameObject.SetActive(false);
            }
            else{
                transform.GetChild(0).gameObject.SetActive(false);
                transform.GetChild(1).gameObject.SetActive(true);
            }
        }
    }
}
