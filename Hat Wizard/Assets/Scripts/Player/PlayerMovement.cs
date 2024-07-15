using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityUtils;

public class PlayerMovement : MonoBehaviour
{
    private Vector2 m_Look;
    private Vector2 m_Move;
    private Vector2 m_Rotation;

    private Vector3 worldPos;

    [SerializeField] private float rotateSpeed;
    [SerializeField] private float moveSpeed;

    // Update is called once per frame
    public void Update()
    {
        // Update orientation first, then move. Otherwise move orientation will lag
        // behind by one frame.
        //Look(m_Look);
        Move(m_Move);
    }

    private void Move(Vector2 direction)
    {
        if (direction.sqrMagnitude < 0.01)
            return;

        var scaledMoveSpeed = moveSpeed * Time.deltaTime;
        // For simplicity's sake, we just keep movement in a single plane here. Rotate
        // direction according to world Y rotation of player.
        var move = new Vector3(direction.x, 0, direction.y);
        transform.forward = Vector3.SlerpUnclamped(transform.forward, move, Time.deltaTime * rotateSpeed);
        transform.position += move * scaledMoveSpeed;
        
    }

    private void Look(Vector2 rotate)
    {
        Debug.Log(rotate);

        var dir = new Vector3(rotate.x, 0, rotate.y).normalized;
        Vector3.Project(dir, transform.forward.With(y:0));

        var point = (transform.position + dir);

        
        
        //cameraController.LookAtPosition = point;

        var rotation = Quaternion.FromToRotation(transform.position, point);
        
        //transform.LookAt(point, Vector3.up);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, 10f);

        // if (rotate.sqrMagnitude < 0.01)
        //     return;
        // var scaledRotateSpeed = rotateSpeed * Time.deltaTime;
        // m_Rotation.y += rotate.x * scaledRotateSpeed;
        // m_Rotation.x = Mathf.Clamp(m_Rotation.x - rotate.y * scaledRotateSpeed, -89, 89);
        // transform.localEulerAngles = m_Rotation;
    }
    
    public void OnMove(InputAction.CallbackContext context)
    {
        m_Move = context.ReadValue<Vector2>();
    }

    public void OnLook(InputAction.CallbackContext context)
    {
        m_Look = context.ReadValue<Vector2>();
        m_Look.x -= (Screen.width / 2f);
        m_Look.x /= Screen.width;
        m_Look.y -= (Screen.height / 2f);
        m_Look.y /= Screen.height;
    }

    private void OnDrawGizmos()
    {
        var dir = Vector3.forward + new Vector3(m_Look.x, 0, m_Look.y).normalized;
        Gizmos.DrawLine(transform.position, transform.position + dir);
    }
}
