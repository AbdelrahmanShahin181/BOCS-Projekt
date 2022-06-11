using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playermovement : MonoBehaviour
{

    public Rigidbody2D player;
    [SerializeField] private float speed ;
    public float moveSpeed= 5f;
    Vector2 movement; 
        public Animator animator;
    // Start is called before the first frame update
    
    void Start()
    {
       // player= GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        player.velocity= player.velocity = new Vector2(Input.GetAxis("Horizontal")*speed,Input.GetAxis("Vertical")*speed);
        
        movement.x=Input.GetAxisRaw("Horizontal");
        movement.y=Input.GetAxisRaw("Vertical");
         animator.SetFloat("Horizontal",movement.x);
        animator.SetFloat("Vertical",movement.y);
        animator.SetFloat("Speed",movement.sqrMagnitude);

/*
animator.SetFloat("Horizontal",Input.GetAxis("Horizontal"));
Vector3 horizontal = new Vector3(Input.GetAxis("Horizontal"),0.0f,0.0f);
transform.position= transform.position +horizontal*speed*Time.deltaTime;

animator.SetFloat("Vertical",Input.GetAxis("Vertical"));
Vector3 vertical = new Vector3(0.0f,Input.GetAxis("Vertical"),0.0f);
transform.position= transform.position +vertical*speed*Time.deltaTime;
*/

    }
    
    void FixedUpdate(){
        //player.MovePoistion(player.position + movement * moveSpeed * Time.fixedDeltaTime);  
    }

}
