using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;

public class ClientNetworkTransformManual : NetworkBehaviour
{
    private NetworkVariable<PlayerNetworkState> _netState = new (writePerm: NetworkVariableWritePermission.Owner);

    void Update()
    {
        if (IsOwner)
        {
            _netState.Value = new PlayerNetworkState();
        }
        else
        {
            transform.position = _netState.Value.Position;
        }
    }

    private struct PlayerNetworkState : INetworkSerializable {
        private float _posX, _posY;

        internal Vector3 Position {
            get => new(_posX, 0, _posY);
            set {
                _posX = value.x;
                _posY = value.y;
            }
        }


        public void NetworkSerialize<T>(BufferSerializer<T> serializer) where T : IReaderWriter {
            serializer.SerializeValue(ref _posX);
            serializer.SerializeValue(ref _posY);
        }
    }
}

