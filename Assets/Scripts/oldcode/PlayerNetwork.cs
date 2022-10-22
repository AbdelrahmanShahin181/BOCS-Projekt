using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;

public class PlayerNetwork : NetworkBehaviour
{
    private readonly NetworkVariable<PlayerNetworkData> _netState = new(writePerm: NetworkVariableWritePermission.Owner);
    private Vector3 _velocity;
    [SerializeField] private float _cheapInterpolationTime = 0.1f;

    void Start()
    {
        _netState.Value = new PlayerNetworkData
            {
                Position = new Vector3(1, -58, 0),
            };
    }
    void Update()
    {
        if (IsOwner)
        {
            _netState.Value = new PlayerNetworkData
            {
                Position = transform.position,
            };
        }
        else
        {
            transform.position = Vector3.SmoothDamp(transform.position, _netState.Value.Position, ref _velocity, _cheapInterpolationTime);
        }
    }

    struct PlayerNetworkData : INetworkSerializable
    {
        private float _x , _y;
        internal Vector3 Position{
            get => new Vector3(_x, _y, 0);
            set{
                _x = value.x;
                _y = value.y;
            }
        }

        public void NetworkSerialize<T>(BufferSerializer<T> serializer) where T: IReaderWriter
        {
            serializer.SerializeValue(ref _x);
            serializer.SerializeValue(ref _y);
        }
    }
}