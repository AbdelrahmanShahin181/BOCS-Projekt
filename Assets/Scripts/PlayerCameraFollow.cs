using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class PlayerCameraFollow : MonoBehaviour
{
    private CinemachineVirtualCamera cinemachineVirtualCamera;
    public static PlayerCameraFollow Instance;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        cinemachineVirtualCamera = GetComponent<CinemachineVirtualCamera>();
    }

    public void FollowPlayer(Transform target)
    {
        cinemachineVirtualCamera.Follow = target;
    }
   
}
