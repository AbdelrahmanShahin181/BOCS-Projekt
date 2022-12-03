using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountFood : MonoBehaviour
{

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
        foodCount += 1;
        collision.GetComponent<Rigidbody2D>().mass = collision.GetComponent<Rigidbody2D>().mass*2;
    }

    private void OnTriggerExit2D(Collider2D collision){
        foodCount -= 1;
        collision.GetComponent<Rigidbody2D>().mass = collision.GetComponent<Rigidbody2D>().mass/2;
    }
}
