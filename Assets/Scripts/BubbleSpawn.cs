using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleSpawner : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject bubble;
    public int bubbleCount;
    private int currBubbleCount;
    private float waitTimer;
    private float maxYBubbles;
    private float minYBubbles;
    private Vector3[] bubblePos;

    void Start()
    {
        maxYBubbles = 1.5f;
        minYBubbles = 1f;
        currBubbleCount = 0;
        waitTimer = 0.8f;
        bubblePos = new Vector3[]
        {
            new Vector3(26.19f, 0.15f, 0f),
            new Vector3(27.01f, 0.97f, 0f),
            new Vector3(26.34f, 1.89f, 0f),
            new Vector3(26.01f, 1.54f, 0f),
            new Vector3(26.43f, 2.97f, 0f),

        };
    }

    // Update is called once per frame
    void Update()
    {
        waitTimer = waitTimer - Time.deltaTime;

        if (currBubbleCount <= bubbleCount & waitTimer <= 0)
        {
            
            Vector3 bubblePosition = bubblePos[currBubbleCount];
            Instantiate(bubble, bubblePosition, Quaternion.identity);
            currBubbleCount++;
            maxYBubbles = maxYBubbles + 0.6f;
            minYBubbles = minYBubbles + 0.6f;
            waitTimer = 0.8f;

        }

    }
}
