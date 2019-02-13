using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Screen_Shake : MonoBehaviour
{
    private Transform transform;

    private float duration = 0f;

    private float mag = 0.7f;

    private float dampening = 1f;

    Vector3 startPos;

    private void Awake()
    {
        transform = Camera.main.transform;
    }

    private void OnEnable()
    {
        startPos = transform.localPosition;
    }

    private void Update()
    {
        if ( duration > 0)
        {
            transform.localPosition = startPos + Random.insideUnitSphere * mag;
            duration -= Time.deltaTime * dampening;
        }
        else
        {
            duration = 0f;
            transform.localPosition = startPos;
        }
    }

    public void TriggerShake()
    {
        duration = 1.0f;
    }

}
