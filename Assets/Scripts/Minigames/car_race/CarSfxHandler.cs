using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSfxHandler : MonoBehaviour
{


    [Header("Audio sources")]
    public AudioSource tireScreechingAudioSource;
    public AudioSource engineAudioSource;
    public AudioSource carHitAudioSource;

    float desiredEnginePitch = 0.5f;
    float tireScreechPitch = 0.5f;

    // Components
    CarController carController;

    private void Awake() {
        carController = GetComponent<CarController>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        UpdateEngineSFX();
        UpdateTireScreechingSFX();
    }

    void UpdateEngineSFX() {
        float velocityMagnitude = carController.GetVelocityMagnitude();
        float desiredEngineVolume = velocityMagnitude * 0.05f;
        desiredEnginePitch = velocityMagnitude * 0.2f;

        desiredEngineVolume = Mathf.Clamp(desiredEngineVolume, 0.2f, 1.0f);
        desiredEnginePitch = Mathf.Clamp(desiredEnginePitch, 0.5f, 2f);

        engineAudioSource.volume = Mathf.Lerp(engineAudioSource.volume, desiredEngineVolume, Time.deltaTime * 10);
        engineAudioSource.pitch = Mathf.Lerp(engineAudioSource.pitch, desiredEnginePitch, Time.deltaTime * 1.5f);
    }

    void UpdateTireScreechingSFX() {
        if (carController.IsTireScreeching(out float lateralVelocity, out bool isBreaking)) {
            if (isBreaking){
                tireScreechingAudioSource.volume = Mathf.Lerp(tireScreechingAudioSource.volume, 1.0f, Time.deltaTime * 10);
                tireScreechPitch = Mathf.Lerp(tireScreechPitch, 0.5f, Time.deltaTime * 10);
            } else {
                tireScreechingAudioSource.volume = Mathf.Abs(lateralVelocity) * 0.05f;
                tireScreechPitch = Mathf.Abs(lateralVelocity) * 0.1f;
            }
        } else {
            tireScreechingAudioSource.volume = Mathf.Lerp(tireScreechingAudioSource.volume, 0.0f, Time.deltaTime * 10);
        }
    }

    void OnCollisionEnter2D(Collision2D collision2D) {
        float relativeVelocity = collision2D.relativeVelocity.magnitude;
        float volume = relativeVelocity * 0.1f;
        carHitAudioSource.volume = volume;
        carHitAudioSource.pitch = Random.Range(0.95f, 1.05f);
        if (!carHitAudioSource.isPlaying) {
            carHitAudioSource.Play();
        }
    }
}
