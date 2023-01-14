using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timeline : MonoBehaviour
{
    public int level = 0;
    private static GameObject instance;

    private void Awake() {
        DontDestroyOnLoad(this.gameObject);
        if (instance == null)
            instance = gameObject;
        else
            Destroy(gameObject);
    }
    
}
