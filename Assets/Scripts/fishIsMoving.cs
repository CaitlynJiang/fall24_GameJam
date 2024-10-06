using UnityEngine;

public class fishIsMoving : MonoBehaviour
{
    private Vector3 previousPosition;
    public bool isMoving;

    void Start()
    {
        previousPosition = transform.position;
        isMoving = true;
    }

    void Update()
    {
        // Check if the player has moved by comparing positions
        if (transform.position != previousPosition)
        {
            isMoving = true;
        }
        else
        {
            isMoving = false;
        }

        // Update previous position to current
        previousPosition = transform.position;
    }
}