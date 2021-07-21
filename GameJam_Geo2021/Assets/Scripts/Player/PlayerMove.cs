using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerInput))]
public class PlayerMove : MonoBehaviour
{
    Vector2 dragInputDir = Vector3.zero;
    float dragMag = 0f;
    Vector3 moveDir;
    public float moveSpeed = 10f;

    public float timeToStop = 3f;
    Rigidbody rb;
    GroundCheck groundCheck;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        groundCheck = GetComponentInChildren<GroundCheck>();
    }
    public void GetInput(Vector2 dragDirection, float magnitude)
    {
        dragInputDir = dragDirection;
        dragMag = magnitude;
        moveDir.x = dragInputDir.x;
        moveDir.z = dragInputDir.y;
    }
    private void FixedUpdate()
    {
        if (groundCheck.IsGrounded)
        {
            rb.velocity = moveDir * moveSpeed * Time.deltaTime;
            Count(moveDir, timeToStop);
        }
    }
    void Count(Vector3 moveDirection, float timeToStop)
    {
        float timeCount = 0f;
        if(rb.velocity.magnitude >= .15f)
        {
            timeCount += Time.fixedDeltaTime;
        }
        if (Input.GetMouseButtonDown(0))
        {
            timeCount = 0f;
            timeCount += Time.fixedDeltaTime;
        }
        if (Input.GetMouseButton(0))
        {
            timeCount = 0f;
        }
        if (Input.GetMouseButtonUp(0))
        {
            timeCount = 0f;
            timeCount += Time.fixedDeltaTime;
        }
        if(timeCount >= timeToStop)
        {

        }
    }
    
}
