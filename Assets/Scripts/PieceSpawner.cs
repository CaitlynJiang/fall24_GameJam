using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;  // Import the Unity UI namespace to access the Text component

public class PieceSpawner : MonoBehaviour
{
    public GameObject[] piecePrefabs;  // Array of different piece prefabs to spawn
    public Transform spawnPoint;       // The position where pieces will spawn
    public float amplitude = 3.0f;     // Amplitude of the motion for each piece
    public Text levelCompleteText;     // Reference to the "Level Complete" UI text

    private GameObject currentPiece;   // The currently active piece
    private int currentPieceIndex = 0; // Track the index of the piece to spawn next
    private int curr = 0;              // Count how many pieces have been spawned
    private bool lastPieceSpawned = false; // Flag to stop spawning after the last piece

    private void Start()
    {
        levelCompleteText.gameObject.SetActive(false); // Hide the text at the start
        SpawnPiece();  // Spawn the first piece at the start
    }

    private void Update()
    {
        // Check if the current piece has completely stopped (both X and Y axis)
        if (currentPiece != null)
        {
            PieceMovement pieceMovement = currentPiece.GetComponent<PieceMovement>();

            if (pieceMovement != null && pieceMovement.IsMovementStopped())
            {
                // If the piece has stopped and the last piece hasn't been spawned, spawn the next piece
                if (!lastPieceSpawned)
                {
                    SpawnPiece();
                }
				else
				{
					levelCompleteText.gameObject.SetActive(true);  // Display "Level Complete" message
				}
            }
        }
    }

    // Method to spawn a new piece from the array
    private void SpawnPiece()
    {
        // Spawn the next piece from the array
        currentPiece = Instantiate(piecePrefabs[currentPieceIndex], spawnPoint.position, Quaternion.identity);

        // Set random movement properties for the new piece
        PieceMovement pieceMovement = currentPiece.GetComponent<PieceMovement>();
        if (pieceMovement != null)
        {
            if (curr < 3)
            {    
                pieceMovement.x_speed = Random.Range(0.5f, 3.0f);  // Random X 
                pieceMovement.y_speed = Random.Range(0.5f, 3.0f);  // Random Y 
            }
            else if (curr < 8)
            {    
                pieceMovement.x_speed = Random.Range(2.0f, 5.0f);  // Random X 
                pieceMovement.y_speed = Random.Range(2.0f, 5.0f);  // Random Y 
            }
            else
            {    
                pieceMovement.x_speed = Random.Range(4.0f, 7.0f);  // Random X 
                pieceMovement.y_speed = Random.Range(4.0f, 7.0f);  // Random Y 
            }
            pieceMovement.amplitude = amplitude;  // Keep amplitude constant
        }

        // Check if this is the last piece in the array
        if (currentPieceIndex == piecePrefabs.Length - 1)
        {
            lastPieceSpawned = true;  // Set flag to stop further spawning
        }
		
        // Update the index for the next piece (but don't go beyond the array length)
        currentPieceIndex = (currentPieceIndex + 1) % piecePrefabs.Length;

        // Increment the number of pieces spawned
        curr++;
    }
}
