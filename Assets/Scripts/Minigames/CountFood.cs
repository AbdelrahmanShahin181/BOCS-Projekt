using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CountFood : MonoBehaviour
{
    public TextMeshProUGUI score;
    public int foodCount = -2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision){
        if (collision.CompareTag("Food")) {
            foodCount += 1;
            score.text = foodCount.ToString();
            collision.GetComponent<Rigidbody2D>().mass = collision.GetComponent<Rigidbody2D>().mass*2;
        }
    }

    private void OnTriggerExit2D(Collider2D collision){
        if (collision.CompareTag("Food")) {
            foodCount -= 1;
            score.text = foodCount.ToString();
            collision.GetComponent<Rigidbody2D>().mass = collision.GetComponent<Rigidbody2D>().mass/2;
        }
    }
}
