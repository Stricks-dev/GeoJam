using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLookPlayer : MonoBehaviour
{
    public GameObject player;
    Transform playerTransform;

    public float distance = 20f;

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

        transform.position = _playerTransform.position - dir * distance;
        transform.forward = Vector3.Lerp(transform.forward, dir, smoothingLook * Time.deltaTime);
    }
}
