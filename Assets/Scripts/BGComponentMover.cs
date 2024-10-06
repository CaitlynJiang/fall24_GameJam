using UnityEngine;

public class BGComponentMover : MonoBehaviour
{
    public float moveSpeed; // Speed for this particular object
    public float moveDistance; // How far the object should move
    public GameObject player;
    private Vector3 startPos;
    private float targetX;

    private FishIsMoving playerController; // Reference to the PlayerController

    void Start()
    {
        startPos = transform.position;
        targetX = startPos.x + moveDistance;

        // Find the player object in the scene and get the PlayerController script

        //playerController = player.GetComponent<FishIsMoving>();
    }
       

    void Update()
    {
        if(playerController == null)
        {
            playerController = player.GetComponent<FishIsMoving>();
        }
        if (playerController != null && playerController.isMoving)
        {
            // Move the object toward the target if the player is moving
            float newX = Mathf.MoveTowards(transform.position.x, targetX, moveSpeed * Time.deltaTime);
            transform.position = new Vector3(newX, startPos.y, startPos.z);
            Debug.Log(moveSpeed + " " + gameObject.name);

        }
    }
}
