using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerInput))]
public class PlayerMove : MonoBehaviour
{

    public PlayerInfo info;
    [Space]
    PlayerInput input;

    Vector3 dirToAddForce;
    Rigidbody rb;

    GroundCheck check;
    public event Action OnPlayerStop;
    [HideInInspector] public Vector3 lastRecordPos = Vector3.zero;

    [Space]
    public float force = 100f;
    [Space]
    public float timeToReset = 3f;

    [HideInInspector] public bool addedForce;
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
    float timeCount = 0f;
    private void FixedUpdate()
    {
        if (check.IsGrounded)
        {
            if(dirToAddForce != Vector3.zero)
            {
                rb.velocity = dirToAddForce * force * Time.fixedDeltaTime;
                if(dirToAddForce != Vector3.zero)
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
                if (rb.velocity.magnitude >= .15f)
                {
                    if (timeCount >= timeToReset)
                    {
                        addedForce = true;
                        lastRecordPos = transform.position;
                        OnPlayerStop?.Invoke();
                        timeCount = 0f;
                    }
                }
            }
        }
    }
}
[System.Serializable]
public class PlayerInfo
{
    public int id;
    public string playerName;
    public PlayerType playerType;

    public enum PlayerType
    {
        Circle,Rhombus,Star,Triangle,Trapezoid
    }
}
