using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLookPlayer : MonoBehaviour
{
    public GameObject player;
    Transform playerTransform;

    public float smoothingLook = 5f;
    private void Start()
    {
        playerTransform = player.transform;
    }
    private void Update()
    {
        LookAtPlayer(playerTransform);
    }
    void LookAtPlayer(Transform _playerTransform)
    {
        Vector3 dir = _playerTransform.position - transform.position;
        dir.Normalize();
        transform.forward = Vector3.Lerp(transform.forward, dir, smoothingLook * Time.deltaTime);
    }
}
