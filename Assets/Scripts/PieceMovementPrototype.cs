using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PieceMovement : MonoBehaviour
{
    public float x_speed = 1.0f;  // Speed of the motion
    public float y_speed = 1.0f;
    public float amplitude = 3.0f;  // Amplitude (the distance of the motion)

    public Vector3 startPosition;  // Initial position of the object

    private bool stopXMovement = false;  // Flag to stop X movement
    private bool stopYMovement = false;  // Flag to stop Y movement
    private float frozenXPosition;       // Store the X position when 'A' is pressed
    private float frozenYPosition;       // Store the Y position when 'L' is pressed

    private void Start()
    {
        // Record the initial position of the object
        startPosition = transform.position;
        frozenXPosition = startPosition.x;  // Initialize frozenXPosition to the starting X position
        frozenYPosition = startPosition.y;  // Initialize frozenYPosition to the starting Y position
    }

    void Update()
    {
        // Check if the player presses the 'A' key to stop X movement
        if (Input.GetKeyDown(KeyCode.A))
        {
            stopXMovement = true;
            frozenXPosition = transform.position.x;  // Store the current X position
        }

        // Check if the player presses the 'L' key to stop Y movement
        if (Input.GetKeyDown(KeyCode.L))
        {
            stopYMovement = true;
            frozenYPosition = transform.position.y;  // Store the current Y position
        }

        // Calculate the X position, or freeze it if X movement is stopped
        float x = stopXMovement ? frozenXPosition : (amplitude * Mathf.Cos(Time.time * x_speed) * -1 + startPosition.x);

        // Calculate the Y position, or freeze it if Y movement is stopped
        float y = stopYMovement ? frozenYPosition : (amplitude * Mathf.Cos(Time.time * y_speed) * -1 + startPosition.y);

        // Update the object's position
        transform.position = new Vector3(x, y, startPosition.z);
    }

    // Method to check if both X and Y movements have stopped
    public bool IsMovementStopped()
    {
        return stopXMovement && stopYMovement;
    }
}
