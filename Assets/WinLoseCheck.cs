using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinLoseCheck : MonoBehaviour
{
    public GameObject inputs;
    public float targetTime = 10.0f;
    private bool won = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        targetTime -= Time.deltaTime;
        if (targetTime<=0.0f) {
            for(int i = 0; i<4; i++) {
                if(!inputs.transform.GetChild(i).transform.GetChild(2).gameObject.activeSelf){
                    won = false;
                    Debug.Log("Verloren!");
                }
            }
        }
    }
}
