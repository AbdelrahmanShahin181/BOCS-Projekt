using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timeline : MonoBehaviour
{
    public int level = 0;

    private void Awake() {
        DontDestroyOnLoad(this.gameObject);
    }
    
}
