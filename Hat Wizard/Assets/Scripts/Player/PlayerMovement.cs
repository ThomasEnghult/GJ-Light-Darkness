using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private Vector2 m_Move;

    [SerializeField] private float rotateSpeed;
    [SerializeField] private float moveSpeed;

    // Update is called once per frame
    public void Update()
    {
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
    
    public void OnMove(InputAction.CallbackContext context)
    {
        m_Move = context.ReadValue<Vector2>();
    }
}
