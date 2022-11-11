using UnityEngine;
using Unity.Netcode;

public class PlayerController : NetworkBehaviour
{

    public float speed ;
    private Rigidbody2D myRigidbody ;
    private SpriteRenderer sprite ;
    private Vector3 change;
    private Animator animator ;
    // Start is called before the first frame update
    void Start()
    {
        if (!IsOwner) return;
        animator = GetComponent<Animator>();
        myRigidbody = GetComponent<Rigidbody2D>();
        PlayerCameraFollow.Instance.FollowPlayer(transform);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!IsOwner) return;
        change = Vector3.zero;
        change.x = Input.GetAxisRaw("Horizontal");
        change.y = Input.GetAxisRaw("Vertical");     
        if(change != Vector3.zero){
            MoveCharacter();
            animator.SetFloat("MoveX",change.x);
            animator.SetFloat("MoveY",change.y);
            animator.SetBool("moving",true);


        }  else{
            animator.SetBool("moving",false);
        } 
    }
    void MoveCharacter(){
        myRigidbody.MovePosition(transform.position+ change*speed* Time.deltaTime);
    }

    public override void OnNetworkDespawn()
    {
        if (!IsOwner) Destroy(this);
    }
    public override void OnNetworkSpawn()
    {
        if (!IsOwner) return;
    }
    void changeLayer() {
        sprite.sortingLayerName = "2ndFloor";
    }
}
