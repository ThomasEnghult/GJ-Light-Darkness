using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform target;

    [SerializeField] private Vector3 offset;

    [SerializeField, Range(0, 1f)] private float maxDelta;
    
    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, (target.position + offset), maxDelta);
    }
}
