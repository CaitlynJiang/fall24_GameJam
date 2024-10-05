using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PieceSpawn : MonoBehaviour
{
    public GameObject piecePrefab;  // Prefab of the piece to spawn
    public Transform spawnPoint;    // The position where pieces will spawn
    public float x_speed = 5.0f;    // Speed of the X-axis motion for each piece
    public float y_speed = 3.0f;    // Speed of the Y-axis motion for each piece
    public float amplitude = 3.0f;  // Amplitude of the motion for each piece

    private GameObject currentPiece;  // The currently active piece

    private void Start()
    {
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
                // If the piece has stopped, spawn the next piece
                SpawnPiece();
            }
        }
    }

    // Method to spawn a new piece
    private void SpawnPiece()
    {
        currentPiece = Instantiate(piecePrefab, spawnPoint.position, Quaternion.identity);  // Spawn the piece at the spawnPoint

        // Set the movement properties of the new piece
        PieceMovement pieceMovement = currentPiece.GetComponent<PieceMovement>();
        if (pieceMovement != null)
        {
            pieceMovement.x_speed = x_speed;
            pieceMovement.y_speed = y_speed;
            pieceMovement.amplitude = amplitude;
        }
    }
}
