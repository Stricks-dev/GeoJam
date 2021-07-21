using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public float maxDragStartFromPlayer = 15f;
    [Space]
    [HideInInspector] public Vector2 DragDirection;
    [HideInInspector] public float DragMagnitude;

    PlayerMove playerMove;
    private void Start()
    {
        playerMove = GetComponent<PlayerMove>();
    }
    private void Update()
    {
        ReadDragInput();
    }
    void ReadDragInput()
    {
        //Final vars
        Vector2 startPoint = Vector2.zero;
        Vector2 endPoint = Vector2.zero;
        Vector2 dragDirection = Vector2.zero;

        Vector3 playerScreenPos3 = Camera.main.WorldToScreenPoint(transform.position);
        Vector2 mouseScreenPos = Input.mousePosition;
        Vector2 playerScreenPos = new Vector3
        {
            x = playerScreenPos3.x,
            y = playerScreenPos3.y
        };
        Vector2 center = new Vector2
        {
            x = Screen.width / 2,
            y = Screen.height / 2
        };
        Vector2 playerScreenCoordPos = playerScreenPos - center;
        Vector2 mouseScreenCoordPos = mouseScreenPos - center;


        if (Input.GetMouseButtonDown(0))
        {
            Vector2 dragStartPoint = playerScreenCoordPos - mouseScreenCoordPos;
            if(dragStartPoint.magnitude <= maxDragStartFromPlayer)
            {
                startPoint = mouseScreenCoordPos;
            }
        }
        if (Input.GetMouseButtonUp(0))
        {
            Vector2 dragEndPoint = playerScreenCoordPos - mouseScreenCoordPos;
            endPoint = mouseScreenCoordPos;

            dragDirection = endPoint - startPoint;

            //Setting tt to global variables
            DragDirection = dragDirection.normalized * -1f;
            DragMagnitude = dragDirection.magnitude /10f;
            playerMove.GetInput(DragDirection, DragMagnitude);
            DragDirection = Vector2.zero;
        }
    }
}
