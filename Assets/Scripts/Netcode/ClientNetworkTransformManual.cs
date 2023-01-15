using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;

public class ClientNetworkTransformManual : NetworkBehaviour
{
    private NetworkVariable<Vector3> _netPos = new (writePerm: NetworkVariableWritePermission.Owner);
    //private NetworkVariable<UnityEngine.Color> _netColor = new (writePerm: NetworkVariableWritePermission.Owner);

    private NetworkVariable<UnityEngine.Color> _hairColor = new (writePerm: NetworkVariableWritePermission.Owner);
    private NetworkVariable<UnityEngine.Color> _skinColor = new (writePerm: NetworkVariableWritePermission.Owner);
    private NetworkVariable<UnityEngine.Color> _shirtColor = new (writePerm: NetworkVariableWritePermission.Owner);
    private NetworkVariable<UnityEngine.Color> _pantsColor = new (writePerm: NetworkVariableWritePermission.Owner);

    private NetworkVariable<int> _hairTextur = new (writePerm: NetworkVariableWritePermission.Owner);


    void Update()
    {
        if (IsOwner)
        {
            _netPos.Value = transform.position;
            //_netColor.Value = GetComponent<SpriteRenderer>().color;

            _hairColor.Value = GetComponent<SpriteRenderer>().material.GetColor("_CHair");
            _skinColor.Value = GetComponent<SpriteRenderer>().material.GetColor("_CSkin");
            _shirtColor.Value = GetComponent<SpriteRenderer>().material.GetColor("_CShirt");
            _pantsColor.Value = GetComponent<SpriteRenderer>().material.GetColor("_CPants");

            _hairTextur.Value = (int)GetComponent<SpriteRenderer>().material.Getfloat("_HairIndex");
        }
        else
        {
            transform.position = _netPos.Value;
            //GetComponent<SpriteRenderer>().color = _netColor.Value;

            GetComponent<SpriteRenderer>().material.SetColor("_CHair",_hairColor.Value);
            GetComponent<SpriteRenderer>().material.SetColor("_CSkin",_skinColor.Value);
            GetComponent<SpriteRenderer>().material.SetColor("_CShirt",_shirtColor.Value);
            GetComponent<SpriteRenderer>().material.SetColor("_CPants",_pantsColor.Value);

            (int)GetComponent<SpriteRenderer>().material.Getfloat("_HairIndex") = _hairTextur.Value;
            GetComponent<LoadCharacterDesign>().SetBodypart("_Hair", _hairTextur.Value);

        }
    }
    
}
