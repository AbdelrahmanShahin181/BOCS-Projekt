using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Key {W,A,S,D};

public class ChangeLayerScript : MonoBehaviour
{
    public Key up = Key.W;
    public Key down = Key.S;
    public int upFloorNum = 1;
    [SerializeField] GameObject _lowerLevel;
    [SerializeField] GameObject _upperLevel;    

    KeyCode KeyToKeyCode(Key key) {
        switch(key) {
            case Key.W: return KeyCode.W;
            case Key.A: return KeyCode.A;
            case Key.S: return KeyCode.S;
            case Key.D: return KeyCode.D;
        }
        return KeyCode.W;
    }

    KeyCode KeyToKeyDirection(Key key) {
        switch(key) {
            //case Key.W: return Vector3(0);
            case Key.A: return KeyCode.A;
            case Key.S: return KeyCode.S;
            case Key.D: return KeyCode.D;
        }
        return KeyCode.W;
    }


    void OnTriggerExit2D(Collider2D pl) {
        if(pl.tag == "Player") {
        Debug.Log(pl.GetComponent<Transform>().position);
            if(Input.GetKey(KeyToKeyCode(up))) {
                _upperLevel.transform.GetChild(2).gameObject.SetActive(true);
                _upperLevel.transform.GetChild(1).gameObject.SetActive(true);
                _lowerLevel.transform.GetChild(1).gameObject.SetActive(false);
                _lowerLevel.transform.GetChild(0).gameObject.SetActive(false);
                _upperLevel.transform.GetChild(0).gameObject.SetActive(true);
    
                pl.GetComponent<SpriteRenderer>().sortingLayerName = upFloorNum + "_Def";
            }
            if(Input.GetKey(KeyToKeyCode(down))) {
                _upperLevel.transform.GetChild(1).gameObject.SetActive(false);
                _upperLevel.transform.GetChild(2).gameObject.SetActive(false);
                _lowerLevel.transform.GetChild(1).gameObject.SetActive(true);
                _lowerLevel.transform.GetChild(0).gameObject.SetActive(true);
                _upperLevel.transform.GetChild(0).gameObject.SetActive(false);
                
                pl.GetComponent<SpriteRenderer>().sortingLayerName = (upFloorNum-1) +"_Def";
            }
        }
    }
}
