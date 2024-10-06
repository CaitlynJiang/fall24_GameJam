using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParentObjectMovement : MonoBehaviour
{
    public Vector3 moveDirection = Vector3.up;  // Example: Move upwards
    public float moveSpeed = 1.0f;

    private void Update()
    {
        // Move the parent object in the specified direction
        transform.Translate(moveDirection * moveSpeed * Time.deltaTime);
    }
}
