using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class CameraMovement : MonoBehaviour
{
    // Follow the player
    /*public Transform target;
    public float smoothTime = 0.3F;
    private Vector3 velocity = Vector3.zero;

    void Update()
    {
        transform.position = Vector3.SmoothDamp(transform.position, target.transform.position, ref velocity, smoothTime);
    }*/

    private float panSpeed = 30f;

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            var newPosition = new Vector3();

            newPosition.x = Input.GetAxis("Mouse X") * panSpeed * Time.deltaTime;
            newPosition.y = Input.GetAxis("Mouse Y") * panSpeed * Time.deltaTime;

            transform.Translate(-newPosition);
        }
    }
}
