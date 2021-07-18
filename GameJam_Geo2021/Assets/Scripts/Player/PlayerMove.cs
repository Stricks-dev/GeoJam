using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerInput))]
public class PlayerMove : MonoBehaviour
{
    PlayerInput input;
    Vector3 dirToAddForce;
    Rigidbody rb;
    public Transform dirTest;

    GroundCheck check;
    public float force = 100f;
    private void Start()
    {
        input = GetComponent<PlayerInput>();
        rb = GetComponent<Rigidbody>();
        check = GetComponentInChildren<GroundCheck>();
    }
    private void Update()
    {
        dirToAddForce = input.GetDragDir();
    }
    private void FixedUpdate()
    {
        if (check.IsGrounded)
        {
            rb.drag = 1.5f;
        }
        else
        {
            rb.drag = 0.5f;
        }
        rb.AddForce(dirToAddForce * force * Time.deltaTime, ForceMode.Impulse);

        //Add another opposite force to stop player
        if(rb.velocity.magnitude >= .2f && check.IsGrounded)
        {
            Debug.Log("Opposite!");
            rb.AddForce(-rb.velocity.normalized * force * 10f * Time.deltaTime);
            Debug.Log("Force Adding");
        }
    }
}
