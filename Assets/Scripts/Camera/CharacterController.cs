using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterController : MonoBehaviour
{
    [SerializeField] private float walkSpeed = 4f;
    [SerializeField] private FixedJoystick joystick;

    Vector3 forward, right;
    private float moveSpeed;

    void Start()
    {
        forward = Camera.main.transform.forward;
        forward.y = 0;
        forward = Vector3.Normalize(forward);

        // -45 degrees from the world x axis
        right = Quaternion.Euler(new Vector3(0, 90, 0)) * forward;

        // Initial speed
        moveSpeed = walkSpeed;
    }

    void Update()
    {
        if (Input.anyKey)
        {
            Move();
        }
    }

    void Move()
    {
        // Movement speed
        Vector3 rightMovement = right * moveSpeed * joystick.Horizontal;
        Vector3 upMovement = forward * moveSpeed * joystick.Vertical;

        // Calculate what is forward
        Vector3 heading = Vector3.Normalize(rightMovement + upMovement);

        // Set new position
        Vector3 newPosition = transform.position;
        newPosition += rightMovement;
        newPosition += upMovement;

        // Smoothly move the new position
        transform.forward = heading;
        transform.position = Vector3.Lerp(transform.position, newPosition, Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("col");
    }
}
