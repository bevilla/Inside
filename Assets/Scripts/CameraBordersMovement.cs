using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBordersMovement : MonoBehaviour
{
    public float translateSpeed = 0.4f;
    public uint borderMargin = 20;
    public bool normalized = true;
    public bool zoom = true;
    public float zoomSpeed = 0.4f;
    public float nearestZoomY = 2f;
    public float farthestZoomY = 14f;

    [SerializeField]
    float maxX, minX, maxZ, minZ;

    float zoomFactor = 1f;

    void Update()
    {
        zoomFactor = (transform.position.y - nearestZoomY) / (farthestZoomY - nearestZoomY);
        Translate();
        if (zoom)
        {
            Zoom();
        }
    }

    void Translate()
    {
        Vector2 mousePos = Input.mousePosition;
        Vector3 movement = Vector3.zero;

        if (mousePos.x < borderMargin && transform.position.x > minX)
        {
            movement += Vector3.left;
        }
        if (mousePos.x > Screen.width - borderMargin && transform.position.x < maxX)
        {
            movement += Vector3.right;
        }
        if (mousePos.y < borderMargin && transform.position.z > minZ)
        {
            movement += Vector3.back;
        }
        if (mousePos.y > Screen.height - borderMargin && transform.position.x < maxZ)
        {
            movement += Vector3.forward;
        }
        if (normalized)
        {
            movement = movement.normalized;
        }
        transform.position += movement * translateSpeed * Mathf.Sqrt(zoomFactor);
    }

    void Zoom()
    {
        Vector3 position = transform.position + transform.forward * Input.mouseScrollDelta.y * zoomSpeed * Mathf.Sqrt(zoomFactor);

        if (position.y >= nearestZoomY && position.y <= farthestZoomY)
        {
            position.y = Mathf.Clamp(position.y, nearestZoomY, farthestZoomY);
            transform.position = position;
        }
    }
}
