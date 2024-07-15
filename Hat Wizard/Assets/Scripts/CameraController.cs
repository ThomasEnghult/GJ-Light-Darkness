using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private Vector3 offset;
    [SerializeField, Range(0, 1f)] private float maxDelta;

    public Vector3 LookAtPosition { get; set; }
    
    private void Update()
    {
        Vector3 pos = target.position;
        pos = (pos + LookAtPosition) / 2;
        
        transform.position = pos + offset;
    }
}
