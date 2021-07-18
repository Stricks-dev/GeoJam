using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public float maxDistance = 10f;

    float dragMagnitude2D = 0f;
    Vector2 dragDir2D = Vector2.zero;

    Vector3 DragDirection = Vector3.zero;


    public event Action OnDragSuccess;
    public Vector3 GetDragDir()
    {
        return DragDirection;
    }
    public float GetDragMagnitude()
    {
        return dragMagnitude2D;
    }


    private void Update()
    {
        ReadDragInput();
    }
    void ReadDragInput()
    {
        Vector2 mousePos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        Vector2 playerPixelPos = Camera.main.WorldToScreenPoint(transform.position);
        Vector2 clickPos = Vector2.zero;
        Vector2 lastPos = Vector2.zero;

        float distance = 0f;
        if (Input.GetMouseButtonDown(0))
        {
            //Onlf if the mouse is clicked near to the player
            distance = (mousePos - playerPixelPos).magnitude;
            if(distance <= maxDistance)
            {
                clickPos = mousePos;
            }
        }
        if (Input.GetMouseButton(0))
        {
            mousePos = Input.mousePosition;
        }
        if (Input.GetMouseButtonUp(0))
        {
            lastPos.x = Input.mousePosition.x;
            lastPos.y = Input.mousePosition.y;

            dragDir2D = (lastPos - clickPos).normalized;

            DragDirection.x = dragDir2D.x;
            DragDirection.z = dragDir2D.y;

            OnDragSuccess?.Invoke();
        }
    }
}
