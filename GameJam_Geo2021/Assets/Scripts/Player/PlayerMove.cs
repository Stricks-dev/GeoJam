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

    public float force = 100f;
    private void Start()
    {
        input = GetComponent<PlayerInput>();
        rb = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        dirToAddForce = input.GetDragDir();
    }
    private void FixedUpdate()
    {
        
    }
}
