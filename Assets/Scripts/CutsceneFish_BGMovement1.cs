using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cutscene_BGMovement1 : MonoBehaviour
{
    public float moveDistance; // The distance the fish will move to the right
    public float moveSpeed;    // The speed at which the platform moves
    public float durationTimer;
    public bool toMove;

    private Vector3 startPos;         // The starting position of the platform
    private float initialX; // The initial X-position of the platform


    void Start()
    {
        startPos = transform.position;
        initialX = startPos.x;
        toMove = true;
    }

    void Update()
    {
        
        // Calculate the target position for each object based on its unique moveDistance
        float targetX = initialX + moveDistance;

        // Calculate the new position for the platform with individual speed
        float newX = Mathf.MoveTowards(transform.position.x, targetX, moveSpeed * Time.deltaTime);
        print(moveSpeed);

        // Update the platform's position
        transform.position = new Vector3(newX, startPos.y, startPos.z);


    }
}
