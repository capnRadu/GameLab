using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private float panSpeed = 50f;

    private float targetZoom;
    private float zoomVelocity;
    [SerializeField] private float zoomSpeed = 5f;
    [SerializeField] private float minZoom = 3f;
    [SerializeField] private float maxZoom = 10f;
    [SerializeField] private float smoothTime = 0.1f;

    [NonSerialized] public bool isActive = false;

    void Start()
    {
        targetZoom = Camera.main.orthographicSize;
    }

    void Update()
    {
        if (isActive)
        {
            DragAndMove();

            SmoothZoom();
        }
    }

    private void DragAndMove()
    {
        if (Input.GetMouseButton(0))
        {
            var newPosition = new Vector3();

            newPosition.x = Input.GetAxis("Mouse X") * panSpeed * Time.deltaTime;
            newPosition.y = Input.GetAxis("Mouse Y") * panSpeed * Time.deltaTime;

            transform.Translate(-newPosition);

            var currentPos = transform.position;

            currentPos.x = Mathf.Clamp(currentPos.x, -12, 12);
            currentPos.y = Mathf.Clamp(currentPos.y, 4, 8);
            currentPos.z = Mathf.Clamp(currentPos.z, -10, 10);

            transform.position = currentPos;
        }
    }

    private void SmoothZoom()
    {
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        targetZoom -= scroll * zoomSpeed;
        targetZoom = Mathf.Clamp(targetZoom, minZoom, maxZoom);
        Camera.main.orthographicSize = Mathf.SmoothDamp(Camera.main.orthographicSize, targetZoom, ref zoomVelocity, smoothTime);
    }
}
