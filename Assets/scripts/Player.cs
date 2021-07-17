using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using TMPro;
public class Player : MonoBehaviour
{
    public Rigidbody2D player;
    public float moveSpeed;
    public AudioSource source;
    public GameObject DeathParticle;
    public LayerMask wall;
    public LineRenderer line;
    public Vector3 startPosition, EndPosition;
    public static Player instance;
    private void Awake()
    {
        instance = this;
        source = GetComponent<AudioSource>();
    }
    void Start()
    {
      if(player == null)
        {
            player = gameObject.GetComponent<Rigidbody2D>();
        }
        startPosition = transform.position;
        EndPosition = transform.position;
        line = GetComponent<LineRenderer>();
        
    }

    void FixedUpdate()
    {
        line.SetPosition(0, player.position);

        
    }
    private void OnMouseDown()
    {
        startPosition = transform.position;
    }
    private void OnMouseDrag()
    {
        Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        
        line.SetPosition(1, pos);
    }
    private void OnMouseUp()
    {
        Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        EndPosition = pos;
        player.AddForce((EndPosition - startPosition) * moveSpeed);
    }
}