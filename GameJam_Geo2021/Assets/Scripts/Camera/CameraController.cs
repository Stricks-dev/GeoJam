using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;
    Transform playerTransform;

    public float smoothingLook = 5f;

    public Vector3 startOffset;
    private void Start()
    {
        playerTransform = player.transform;
        startOffset = transform.position - playerTransform.position;
    }
    private void Update()
    {
        transform.position = playerTransform.position + startOffset;
    }
}
