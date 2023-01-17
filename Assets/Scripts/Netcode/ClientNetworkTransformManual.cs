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
    private NetworkVariable<int> _skinTextur = new (writePerm: NetworkVariableWritePermission.Owner);
    private NetworkVariable<int> _shirtTextur = new (writePerm: NetworkVariableWritePermission.Owner);
    private NetworkVariable<int> _pantsTextur = new (writePerm: NetworkVariableWritePermission.Owner);

    private NetworkVariable<float> _xDir = new (writePerm: NetworkVariableWritePermission.Owner);
    private NetworkVariable<float> _yDir = new (writePerm: NetworkVariableWritePermission.Owner);
    private NetworkVariable<int> _layer = new (writePerm: NetworkVariableWritePermission.Owner);
    private NetworkVariable<bool> _isWalking = new (writePerm: NetworkVariableWritePermission.Owner);
    private NetworkVariable<bool> _isRunning = new (writePerm: NetworkVariableWritePermission.Owner);

    private NetworkVariable<Vector3> _scale = new (writePerm: NetworkVariableWritePermission.Owner);

    void Start() {
        if (IsOwner)
        {
            gameObject.tag = "Player";
        }
        else
        {
            gameObject.tag = "Multiplayer";
        }
    }


    void Update()
    {
        if (IsOwner)
        {

            _hairColor.Value = GetComponent<SpriteRenderer>().material.GetColor("_CHair");
            _skinColor.Value = GetComponent<SpriteRenderer>().material.GetColor("_CSkin");
            _shirtColor.Value = GetComponent<SpriteRenderer>().material.GetColor("_CShirt");
            _pantsColor.Value = GetComponent<SpriteRenderer>().material.GetColor("_CPants");

            
            _hairTextur.Value = (int)GetComponent<SpriteRenderer>().material.GetFloat("_HairIndex");
            _skinTextur.Value = (int)GetComponent<SpriteRenderer>().material.GetFloat("_SkinIndex");
            _shirtTextur.Value = (int)GetComponent<SpriteRenderer>().material.GetFloat("_ShirtIndex");
            _pantsTextur.Value = (int)GetComponent<SpriteRenderer>().material.GetFloat("_PantsIndex");

            _netPos.Value = transform.position;
            _xDir.Value = GetComponent<Animator>().GetFloat("moveX");
            _yDir.Value = GetComponent<Animator>().GetFloat("moveY");
            _isWalking.Value = GetComponent<Animator>().GetBool("isWalking");
            _isRunning.Value = GetComponent<Animator>().GetBool("isRunning");
            _scale.Value = transform.localScale;
            _layer.Value = GetComponent<PlayerLayerControl>().layer;
        }
        else
        {
            GetComponent<SpriteRenderer>().material.SetColor("_CHair",_hairColor.Value);
            GetComponent<SpriteRenderer>().material.SetColor("_CSkin",_skinColor.Value);
            GetComponent<SpriteRenderer>().material.SetColor("_CShirt",_shirtColor.Value);
            GetComponent<SpriteRenderer>().material.SetColor("_CPants",_pantsColor.Value);

            GetComponent<LoadCharacterDesign>().SetBodypart("_Hair", 0, _hairTextur.Value);
            GetComponent<LoadCharacterDesign>().SetBodypart("_Body", 1, _skinTextur.Value);
            GetComponent<LoadCharacterDesign>().SetBodypart("_Shirt", 2, _shirtTextur.Value);
            GetComponent<LoadCharacterDesign>().SetBodypart("_Pants", 3, _pantsTextur.Value);

            transform.position = _netPos.Value;
            GetComponent<Animator>().SetFloat("moveX", _xDir.Value);
            GetComponent<Animator>().SetFloat("moveY", _yDir.Value);
            GetComponent<Animator>().SetBool("isWalking", _isWalking.Value);
            GetComponent<Animator>().SetBool("isRunning", _isRunning.Value);
            transform.localScale = _scale.Value;
            GetComponent<PlayerLayerControl>().ChangeLayer(_layer.Value);
        }
    }
    
}
