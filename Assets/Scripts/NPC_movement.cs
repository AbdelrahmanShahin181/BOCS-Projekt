using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_movement : MonoBehaviour
{

    public float moveSpeed;
    private Rigidbody2D myRigidbody;
    public bool isWalking;
    public float walkTimeLeft;
    public float walkTimeRight;
    public float walkTimeUp;
    public float walkTimeDown;
    public float walkCounter;
    public float waitTime;
    public float waitCounter;
    private int walkDirection = 0;
    private Animator anim;


   
    void Start()
    {
        anim = GetComponent<Animator>();
        myRigidbody = GetComponent<Rigidbody2D>();
        waitCounter = waitTime;
        //walkCounter = walkTime;
        chooseDirection();
        
    }


    void Update()
    {
        if(isWalking){

            walkCounter -= Time.deltaTime;

            switch (walkDirection)
            {
            case 0:
                myRigidbody.velocity = new Vector2(0, moveSpeed);
                break;
            case 1:
                myRigidbody.velocity = new Vector2(moveSpeed, 0);
                break;
            case 2:
                myRigidbody.velocity = new Vector2(0, -moveSpeed);
                break;
            case 3:
                myRigidbody.velocity = new Vector2(-moveSpeed, 0);
                break; 
            }

            UpdateAnimationAndMove();

            if(walkCounter < 0){
                isWalking = false;
                waitCounter = waitTime;
                anim.SetBool("moving", false);
            }
        }
        else{

            waitCounter -= Time.deltaTime;

            myRigidbody.velocity = Vector2.zero;

            if(waitCounter < 0){
                chooseDirection();
            }
        }
        
    }

    public void chooseDirection()
    {
        walkDirection +=1;
        
        if(walkDirection > 3){
            walkDirection = 0;
        }

        isWalking = true;

        switch (walkDirection)
            {
            case 0:
                walkCounter = walkTimeUp;
                break;
            case 1:
                 walkCounter = walkTimeRight;
                break;
            case 2:
                walkCounter = walkTimeDown;
                break;
            case 3:
                walkCounter = walkTimeLeft;
                break; 
            }
    }
    void UpdateAnimationAndMove()
    {
            anim.SetFloat("Horizontal", myRigidbody.velocity.x);
            anim.SetFloat("Vertical", myRigidbody.velocity.y);  
            anim.SetBool("moving", true);         
    }
}
