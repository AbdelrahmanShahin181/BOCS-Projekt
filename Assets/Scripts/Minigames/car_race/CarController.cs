using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{

    [Header("Car Settings")]
    public float driftFactor = 0.95f;
    public float accelerationFactor = 30.0f;
    public float turnFactor = 3.5f;
    public float maxSpeed = 20.0f;

    // Local variables
    float accelerationInput = 0;
    float steeringInput = 0;
    float rotationAngle = 0;
    float velocityVsUp = 0;

    // Components
    Rigidbody2D carRigidbody2D;


    void Awake()
    {
        carRigidbody2D = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space))
            accelerationFactor *= 2;
    }

    void FixedUpdate() {
        ApplyEngineForce();
        KillOrthogonalVelocity();
        ApplySteering();
    }

    void ApplyEngineForce() {
        velocityVsUp = Vector2.Dot(carRigidbody2D.velocity, transform.up);
        if(velocityVsUp > maxSpeed && accelerationInput > 0) 
            return;
        else if(velocityVsUp < -maxSpeed *0.5f && accelerationInput < 0) 
            return;
        else if (carRigidbody2D.velocity.sqrMagnitude > maxSpeed * maxSpeed && accelerationInput > 0)
            return;

        if(accelerationInput == 0) 
            carRigidbody2D.drag = Mathf.Lerp(carRigidbody2D.drag, 3.0f, Time.deltaTime * 3);
        else carRigidbody2D.drag = 0;

        Vector2 engineForceVector = transform.up * accelerationInput * accelerationFactor;
        carRigidbody2D.AddForce(engineForceVector, ForceMode2D.Force);
    }

    void ApplySteering() {
        float minSpeedBeforeAlllowTurningFactor = (carRigidbody2D.velocity.magnitude / 8);
        minSpeedBeforeAlllowTurningFactor = Mathf.Clamp01(minSpeedBeforeAlllowTurningFactor);
        rotationAngle -= steeringInput * turnFactor * minSpeedBeforeAlllowTurningFactor;
        carRigidbody2D.MoveRotation(rotationAngle);
    }

    public void SetInputVector(Vector2 inputVector) {
        steeringInput = inputVector.x;
        accelerationInput = inputVector.y;

    }

    void KillOrthogonalVelocity() {
        Vector2 forwardVelocity = Vector2.Dot(carRigidbody2D.velocity, transform.up) * transform.up;
        Vector2 rightVelocity = Vector2.Dot(carRigidbody2D.velocity, transform.right) * transform.right;
        carRigidbody2D.velocity = forwardVelocity + rightVelocity * driftFactor;
    }

    float GetLaterVelocity() {
        return Vector2.Dot(carRigidbody2D.velocity, transform.right);
    }
    public float GetVelocityMagnitude()
    {
        return carRigidbody2D.velocity.magnitude;
    }

    public bool IsTireScreeching(out float lateralVelocity, out bool isBreaking) {
        lateralVelocity = GetLaterVelocity();
        isBreaking = false;
        if(accelerationInput < 0 && velocityVsUp > 0) {
            isBreaking = true;
            return true;
        }
        if(Mathf.Abs(lateralVelocity) > 3.5f) {
            return true;
        }
        return false;
    }
}
