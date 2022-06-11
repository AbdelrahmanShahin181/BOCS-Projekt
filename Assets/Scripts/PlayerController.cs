using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public Rigidbody2D player;
    [SerializeField] private float speed;
    // Start is called before the first frame update
    void Start()
    {
        player= GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        player.velocity= player.velocity = new Vector2(Input.GetAxis("Horizontal")*speed,Input.GetAxis("Vertical")*speed);
    }
}
