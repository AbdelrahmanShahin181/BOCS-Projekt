using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class DrawPathHandler : MonoBehaviour
{
    public Transform transformRootObject;

    WayPointNode[] waypointNodes;

    // Start is called before the first frame update
    void Start()
    {
 
    }

    void OnDrawGizmos()
    {
        //Gizmos.color = Color.red;

        if (transformRootObject == null)
            return;

        //Get all Waypoints
        waypointNodes = transformRootObject.GetComponentsInChildren<WayPointNode>();

        //Iterate the list
        foreach (WayPointNode waypoint in waypointNodes)
        {
       
            foreach (WayPointNode nextWayPoint in waypoint.nextWayPointNode)
            {
                if (nextWayPoint != null)
                    Gizmos.DrawLine(waypoint.transform.position, nextWayPoint.transform.position);

            }

        }
    }

}
