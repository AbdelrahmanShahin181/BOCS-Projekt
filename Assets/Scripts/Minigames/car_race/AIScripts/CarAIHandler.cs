using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class CarAIHandler : MonoBehaviour
{

    public enum AIMode {followPlayer, followWayPoints};

    [Header("AI Settings")]
    public AIMode aiMode;

    // Local variables
    Vector3 targetPosition = Vector3.zero;
    Transform targetTransform = null;

    // WayPoints
    WayPointNode currentWayPoint = null;
    WayPointNode[] allWayPoints;

    // Components
    CarController carController;

    void Awake()
    {
        carController = GetComponent<CarController>();
        allWayPoints = FindObjectsOfType<WayPointNode>();
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector2 inputVector = Vector2.zero;

        switch (aiMode)
        {
            case AIMode.followPlayer:
                FollowPlayer();
                break;
            case AIMode.followWayPoints:
                FollowWayPoints();
                break;
        }
        inputVector.x = TurnTowardTarget();
        inputVector.y = ApplyThrottleOrBrake(inputVector.x);

        carController.SetInputVector(inputVector);
    }

    void FollowPlayer(){
        if(targetTransform == null){
            targetTransform = GameObject.FindGameObjectWithTag("Player").transform;
        }
        if (targetTransform != null)
        {
            targetPosition = targetTransform.position;
        }
    }

    void FollowWayPoints(){
        if(currentWayPoint == null){
            currentWayPoint = FindClosestWayPoint();
        }
        if(currentWayPoint != null){
            targetPosition = currentWayPoint.transform.position;
            float distanceToWayPoint = (targetPosition - transform.position).magnitude;
            if(distanceToWayPoint <= currentWayPoint.minDistanceToReachWayPoint){
                currentWayPoint = currentWayPoint.nextWayPointNode[Random.Range(0, currentWayPoint.nextWayPointNode.Length)];
            }
        }
    }

    WayPointNode FindClosestWayPoint(){
        return allWayPoints.OrderBy(x => Vector3.Distance(transform.position, x.transform.position)).FirstOrDefault();
    }

    float TurnTowardTarget(){
        Vector3 vectorToTarget = targetPosition - transform.position;
        vectorToTarget.Normalize();
        float angleToTarget = Vector2.SignedAngle(transform.up, vectorToTarget);
        angleToTarget *= -1;
        float steerAmount = angleToTarget / 45.0f;
        steerAmount = Mathf.Clamp(steerAmount, -1, 1);

        return steerAmount;
    }

    float ApplyThrottleOrBrake(float inputX){
        return 1.05f - Mathf.Abs(inputX)/1.0f;
    }
}
