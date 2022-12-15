using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DespawnMirror : MonoBehaviour
{

    public GameObject Platform;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //gameObject.SetTransformX = Platform.GetComponent<Transform>().position.x;
        //transform.position.x = Platform.GetComponent<Transform>().position.x;
        transform.position = new Vector3(Platform.GetComponent<Transform>().position.x, transform.position.y, transform.position.z);
    }
}
