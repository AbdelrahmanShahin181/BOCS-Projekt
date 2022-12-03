using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParentToBowl : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D coll)
{
    if (coll.gameObject.tag == "Bowl")
    {
        Transform bowl = coll.gameObject.transform;
        transform.SetParent(bowl);
    }
}

void OnCollisionExit2D(Collision2D coll)
{
    if (coll.gameObject.tag == "Bowl")
    {
        
        transform.SetParent(null);
    }
}
}
