using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishSwimming : MonoBehaviour
{
    public float speed = 2f;  // Speed of the movement
    public float height = 1f; // Maximum movement height

    private float startY;

    // Start is called before the first frame update
    void Start()
    {
        startY = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        float newY = startY + Mathf.Sin(Time.time * speed) * height;
        transform.position = new Vector3(transform.position.x, newY, transform.position.z);
    }
}
