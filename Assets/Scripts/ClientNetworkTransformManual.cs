using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;

public class ClientNetworkTransformManual : NetworkBehaviour
{
    private NetworkVariable<Vector3> _netPos = new (writePerm: NetworkVariableWritePermission.Owner);
    private NetworkVariable<Color> _netColor = new (writePerm: NetworkVariableWritePermission.Owner);

    void Update()
    {
        if (IsOwner)
        {
            _netPos.Value = transform.position;
            _netColor.Value = GetComponent<SpriteRenderer>().color;
        }
        else
        {
            transform.position = _netPos.Value;
            GetComponent<SpriteRenderer>().color = _netColor.Value;
        }
    }
    
}
