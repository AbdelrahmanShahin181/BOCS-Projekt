using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputWireBehaviour : MonoBehaviour
{
    InputWireStats inputWireS;
    // Start is called before the first frame update
    void Start()
    {
        inputWireS = gameObject.GetComponent<InputWireStats>();
    }

    // Update is called once per frame
    void Update()
    {
        ManageLight();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<PoweredWireStats>())
        {
            PoweredWireStats poweredWireS = collision.GetComponent<PoweredWireStats>();
            if (poweredWireS.objectColor == inputWireS.objectColor)
            {
                poweredWireS.connected = true;
                inputWireS.connected = true;
                poweredWireS.connectedPosition = gameObject.transform.position;
            }
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<PoweredWireStats>())
        {
            PoweredWireStats poweredWireS = collision.GetComponent<PoweredWireStats>();
            if (poweredWireS.objectColor == inputWireS.objectColor)
            {
                poweredWireS.connected = false;
                inputWireS.connected = false;
            }
        }
    }

    void ManageLight()
    {
        if (inputWireS.connected)
        {
            inputWireS.ledOn.SetActive(true);
            inputWireS.ledOff.SetActive(false);
        }
        else
        {
            inputWireS.ledOn.SetActive(false);
            inputWireS.ledOff.SetActive(true);
        }
    }
}
