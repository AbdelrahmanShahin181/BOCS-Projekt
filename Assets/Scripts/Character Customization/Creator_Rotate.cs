using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Creator_Rotate : MonoBehaviour
{

    [SerializeField] public GameObject player;
    private int rotation = 0;
    private Animator animator;
    private int prevX = 0;
    // Start is called before the first frame update
    void Start()
    {
        animator = player.GetComponent<Animator>();
        animator.SetFloat("moveX", 0);
        animator.SetFloat("moveY", -1);
    }

    public void Rotate(int dir) {
        if (dir == 1) {
            rotation++;
        }
        else {
            rotation --;
        }
        if (rotation > 3) {
            rotation = 0;
        }
        if (rotation < 0) {
            rotation = 3;
        }
        int x = rotation -2;
        if (x == -2) {
            x = 0;
        }
        int y = rotation -1;
        if (y == 2) {
            y = 0;
        }
        if (x == -1 || prevX == -1) {
            Vector3 newScale = player.transform.localScale;
            newScale.x *= -1;
            player.transform.localScale = newScale;
        }
        prevX = x;
        
        animator.SetFloat("moveX", x);
        animator.SetFloat("moveY", y);
    }
}
