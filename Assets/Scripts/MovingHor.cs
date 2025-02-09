using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingHori : MonoBehaviour
{
    public float speed = 2f;  // 移动速度
    public float distance = 1f; // 移动范围

    private float startX;
    // Start is called before the first frame update
    void Start()
    {
        startX = transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        float newX = startX + Mathf.Sin(Time.time * speed) * distance;
        transform.position = new Vector3(newX, transform.position.y, transform.position.z);
    }
}
