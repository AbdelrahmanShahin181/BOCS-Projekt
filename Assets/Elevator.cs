using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour
{
    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setPlayer(GameObject playerInst) {
        player = playerInst;
    }

    public void playerTeleport(int target) {
        player.GetComponent<PlayerLayerControl>().Teleport(target);
    }
}
