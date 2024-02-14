using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class CameraShake : MonoBehaviour
{
    [SerializeField] float shakeMagnitude = 0.5f;
    [SerializeField] float shakeDuration = 0.2f;

    Vector3 _initialPos;

    void Start()
    {
        _initialPos = transform.position;
    }

    public void Play()
    {
        StartCoroutine(CameraShakee());
    }

    private IEnumerator CameraShakee()
    {
        float elapsedTime = 0f;
       while(elapsedTime<shakeDuration)
        {
            transform.position = _initialPos + (Vector3)Random.insideUnitCircle * shakeMagnitude;
            yield return new WaitForEndOfFrame();
            elapsedTime += Time.deltaTime;
        }
        transform.position = _initialPos;

    }
}
