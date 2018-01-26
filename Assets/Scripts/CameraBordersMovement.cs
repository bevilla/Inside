﻿using System.Collections;
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
    public float farestZoomY = 14f;

    void Update()
    {
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

        if (mousePos.x < borderMargin)
        {
            movement += Vector3.left;
        }
        if (mousePos.x > Screen.width - borderMargin)
        {
            movement += Vector3.right;
        }
        if (mousePos.y < borderMargin)
        {
            movement += Vector3.back;
        }
        if (mousePos.y > Screen.height - borderMargin)
        {
            movement += Vector3.forward;
        }
        if (normalized)
        {
            movement = movement.normalized;
        }
        transform.position += movement * translateSpeed;
    }

    void Zoom()
    {
        Vector3 position = transform.position + transform.forward * Input.mouseScrollDelta.y * zoomSpeed;

        if (position.y >= nearestZoomY && position.y <= farestZoomY)
        {
            position.y = Mathf.Clamp(position.y, nearestZoomY, farestZoomY);
            transform.position = position;
        }
    }
}
