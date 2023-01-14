
using UnityEngine;
using System.Collections;


public class PlayerController : MonoBehaviour
{

    public float speed ;
    public HealthManager healthManager;
    private Rigidbody2D myRigidbody ;
    private SpriteRenderer sprite ;
    private Vector3 change;
    private Animator animator ;
    private bool moveLeft = false;
    private bool wasMovingLeft = false;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        myRigidbody = GetComponent<Rigidbody2D>();
        //PlayerCameraFollow.Instance.FollowPlayer(transform);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(Input.GetKey(KeyCode.LeftShift)){
            if(!animator.GetBool("isRunning")){
                animator.SetBool("isRunning", true);
                speed = speed * 2;
            }
        }
        else {
            if(animator.GetBool("isRunning")){
                animator.SetBool("isRunning", false);
                speed = speed / 2;
            }
        }
        
        //touch input
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            Vector3 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
            touchPosition.z = 0f;
            transform.position = Vector3.MoveTowards(transform.position, touchPosition, speed * Time.deltaTime);
            change = Vector3.zero;
            change.x = touchPosition.x;
            change.y = touchPosition.y;
            if (change != Vector3.zero)
            {
                //Debug.Log("moving");
                MoveCharacter();
                
                if(Mathf.Abs(change.x) < Mathf.Abs(change.y)) {
                    animator.SetFloat("moveX", 0);
                    animator.SetFloat("moveY", change.y);
                }
                else {
                    animator.SetFloat("moveX", change.x);
                    animator.SetFloat("moveY", 0);
                    
                }
                if(change.x < 0) {
                        moveLeft = true;
                        if(moveLeft != wasMovingLeft) {
                            Vector3 newScale = transform.localScale;
                            newScale.x *= -1;
                            transform.localScale = newScale;
                            Debug.Log("Direction Change");
                        }
                        wasMovingLeft = true;
                    }
                    else {
                        moveLeft = false;
                        if(moveLeft != wasMovingLeft) {
                            Vector3 newScale = transform.localScale;
                            newScale.x *= -1;
                            transform.localScale = newScale;
                            Debug.Log("Direction Change");
                        }
                        wasMovingLeft = false;
                    }
                animator.SetBool("isWalking", true);
            }
            else
            {
                animator.SetBool("isWalking", false);
            }

        }else{
            change = Vector3.zero;
            change.x = Input.GetAxisRaw("Horizontal");
            change.y = Input.GetAxisRaw("Vertical");     
            if(change != Vector3.zero){
                MoveCharacter();
                if(Mathf.Abs(change.x) < Mathf.Abs(change.y)) {
                    animator.SetFloat("moveX", 0);
                    animator.SetFloat("moveY", change.y);
                }
                else {
                    animator.SetFloat("moveX", change.x);
                    animator.SetFloat("moveY", 0);
                }

                if(change.x < 0) {
                        moveLeft = true;
                        if(moveLeft != wasMovingLeft) {
                            Vector3 newScale = transform.localScale;
                            newScale.x *= -1;
                            transform.localScale = newScale;
                            Debug.Log("Direction Change");
                        }
                        wasMovingLeft = true;
                    }
                    else {
                        moveLeft = false;
                        if(moveLeft != wasMovingLeft) {
                            Vector3 newScale = transform.localScale;
                            newScale.x *= -1;
                            transform.localScale = newScale;
                            Debug.Log("Direction Change");
                        }
                        wasMovingLeft = false;
                    }
                animator.SetBool("isWalking",true);


            }  else{
                animator.SetBool("isWalking",false);
            } 
        }

        
    }
    void MoveCharacter(){
        myRigidbody.MovePosition(transform.position+ change*(speed/2 + (speed/2* healthManager.currentHealth /10)) * Time.deltaTime);
    }

}

