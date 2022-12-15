using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TellerMove : MonoBehaviour
{

    public int moveSpeed;

    private Rigidbody2D myrigidbody;
    // Start is called before the first frame update
    void Start()
    {
        myrigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 movement = Vector2.zero;

        /*if(myrigidbody.velocity.x<0) {
            myrigidbody.velocity = new Vector2(-moveSpeed, 0);
        }

        else{
            myrigidbody.velocity = new Vector2(moveSpeed, 0);
        }*/
        

 
        if(Input.GetKey(KeyCode.A))
        {
            //movement.x = (transform.right*Time.deltaTime*-moveSpeed).x;
            myrigidbody.velocity = new Vector2(-moveSpeed, 0);
        }
        if(Input.GetKey(KeyCode.D))
        {
            //movement.x = (transform.right*Time.deltaTime*moveSpeed).x;
            myrigidbody.velocity = new Vector2(moveSpeed, 0);
        }
 
        //movement = movement + (Vector2)(transform.position);
 
        //GetComponent<Rigidbody2D>().MovePosition(movement);
    }

    private void OnTriggerEnter2D(Collider2D collision){
        if (collision.CompareTag("DirectionChange")) {
        myrigidbody.velocity = myrigidbody.velocity*(-1);
        }
    }
}
