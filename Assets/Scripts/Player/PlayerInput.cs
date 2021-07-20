using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public float maxMagnitude = 10f;

    float dragMagnitude = 0f;
    Vector3 dragDir = Vector3.zero;

    private void Update()
    {
        ReadDragInput();
    }
    void ReadDragInput()
    {
        Vector2 mousePos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        Vector2 playerPixelPos = Camera.main.WorldToScreenPoint(transform.position);
        Vector2 clickPos = Vector2.zero;

        Vector3 mouseLastPosWorld = Vector3.zero;
        Vector3 clickInWorld = Vector3.zero;
        Vector3 playerWorldPos = transform.position;

        Vector2 firstPos2D = Vector2.zero;
        Vector2 lastPos2D = Vector2.zero;

        float distance = 0f;
        if (Input.GetMouseButtonDown(0))
        {
            //Onlf if the mouse is clicked near to the player
            distance = (mousePos - playerPixelPos).magnitude;
            if(distance <= maxMagnitude)
            {
                clickPos = mousePos;
                Ray ray = Camera.main.ScreenPointToRay(clickPos);
                RaycastHit castData;
                bool raycast = Physics.Raycast(ray, out castData);
                if (raycast)
                {
                    if(castData.collider.name == "PlayerGFX" || castData.collider.name == "Board")
                    {
                        clickInWorld = castData.point;
                    }
                }
                firstPos2D.x = clickInWorld.x;
                firstPos2D.y = clickInWorld.z;
            }
        }
        if (Input.GetMouseButton(0))
        {
            mousePos = Input.mousePosition;
        }
        if (Input.GetMouseButtonUp(0))
        {
            Vector2 lastPos = new Vector2
            {
                x = Input.mousePosition.x,
                y = Input.mousePosition.y
            };
            Ray ray = Camera.main.ScreenPointToRay(lastPos);
            RaycastHit castData;
            bool raycast = Physics.Raycast(ray, out castData);
            if (raycast)
            {
                if (castData.collider.name == "Board")
                {
                    mouseLastPosWorld = castData.point;
                }
            }
            lastPos2D.x = mouseLastPosWorld.x;
            lastPos2D.y = mouseLastPosWorld.z;

            dragMagnitude = (lastPos2D - firstPos2D).magnitude;
            dragDir = (lastPos2D - firstPos2D).normalized;
        }
    }
}
