using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    [SerializeField] float fltShakeDuration = 1f;
    [SerializeField] float fltShakeMagnitude = 0.5f;
    Vector3 initialPosition;

    void Start()
    {
        initialPosition = transform.position; 
    }

    public void Play()
    {
        StartCoroutine(Shake());
    }

    IEnumerator Shake()
    {
        float fltElapsedTime = 0;
        while (fltElapsedTime < fltShakeDuration)
        { 
            transform.position = initialPosition + (Vector3)Random.insideUnitCircle * fltShakeMagnitude;
            fltElapsedTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        transform.position = initialPosition;
    }
}
