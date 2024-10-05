using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PieceMovement : MonoBehaviour
{
    public float x_speed = 1.0f;  // Speed of the motion
	public float y_speed = 1.0f;
    public float amplitude = 3.0f;  // Amplitude (the distance of the motion)

    public Vector3 startPosition;  // Initial position of the object

    private void Start()
    {
        // Record the initial position of the object
        startPosition = transform.position;
    }

    void Update()
    {
        // Update the object's position in a cosine wave pattern along the X- and Y-axis
        float x = amplitude * Mathf.Cos(Time.time * x_speed) * -1;
        float y = amplitude * Mathf.Cos(Time.time * y_speed) * -1;
        transform.position = new Vector3(startPosition.x + x, startPosition.y + y, startPosition.z);

    }
}