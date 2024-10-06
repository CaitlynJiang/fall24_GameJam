using UnityEngine;

public class FishIsMoving : MonoBehaviour
{
    private Vector3 previousPosition;
    public bool isMoving;
    public GameObject bubble;
    public int bubbleCount;
    private int currBubbleCount;
    private float waitTimer;

    private float maxYBubbles;
    private float minYBubbles;

    public float maxXBubbles;
    public float minXBubbles;
    

    void Start()
    {
        maxYBubbles = 1.5f;
        minYBubbles = 1f;

        previousPosition = transform.position;
        isMoving = true;
        currBubbleCount = 0;
        waitTimer = 0.8f;
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
            waitTimer = waitTimer - Time.deltaTime;
            if (currBubbleCount <= bubbleCount & waitTimer <= 0)
            {
                float randX = Random.Range(minXBubbles, maxXBubbles);
                float randY = Random.Range(minYBubbles, maxYBubbles);
                if(currBubbleCount == 0)
                {
                    randX = minXBubbles;
                }
                Vector3 bubblePosition = new Vector3(transform.position.x + randX, transform.position.y + randY, transform.position.z);
                Debug.Log("XPos" + randX + ", yPos " + randY);
                Instantiate(bubble, bubblePosition, Quaternion.identity);
                currBubbleCount++;
                maxYBubbles = maxYBubbles + 0.6f;
                minYBubbles = minYBubbles + 0.6f;
                waitTimer = 0.8f;

            }
        }

        // Update previous position to current
        previousPosition = transform.position;
    }
}