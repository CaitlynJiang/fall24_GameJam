using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutsceneFish_Movement : MonoBehaviour
{
    public float moveDistance = 2.0f; // The distance the fish will move to the right
    public float moveSpeed = 2.0f;    // The speed at which the platform moves
   
    private Vector3 startPos;         // The starting position of the platform
    private float initialX;           // The initial X-position of the platform
    

    void Start()
    {
        startPos = transform.position;
        initialX = startPos.x;
        
        
        
    }

    void Update()
    {
        // Calculate the target position based on the current direction (right or left)
        float targetX = initialX + moveDistance;

        // Calculate the new position for the platform
        float newX = Mathf.MoveTowards(transform.position.x, targetX, moveSpeed * Time.deltaTime);

        // Update the fish's position
        transform.position = new Vector3(newX, startPos.y, startPos.z);
    }
}
