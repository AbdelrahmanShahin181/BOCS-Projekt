using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CemeraMovement : MonoBehaviour
{
    public Transform target;
    public float smoothing;
    GameObject objectToFind;

    // Start is called before the first frame update
    void Start()
    {
        //target = GameObject.FindGameObjectsWithTag("PlayerPerfab")[0].transform;
        target= this.GetComponentInParent<Transform>();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if(transform.position != target.position){
            Vector3 targetPosition = new Vector3(target.position.x, target.position.y, transform.position.z);
            transform.position = Vector3.Lerp(transform.position, targetPosition, smoothing);
        }

    }
}
