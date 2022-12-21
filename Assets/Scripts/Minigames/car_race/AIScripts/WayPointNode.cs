using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPointNode : MonoBehaviour
{
    [Header("WayPoint Settings")]
    public float minDistanceToReachWayPoint = 5;

    public WayPointNode[] nextWayPointNode;
}
