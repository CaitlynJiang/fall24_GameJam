using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;  // Import the Unity UI namespace to access the Text component

#if UNITY_EDITOR
using UnityEditor;  // Import the Unity Editor namespace to access PrefabUtility
#endif

public class PieceSpawner : MonoBehaviour
{
    public GameObject[] piecePrefabs;  // Array of different piece prefabs to spawn
    public Transform spawnPoint;       // The position where pieces will spawn
    public float amplitude = 3.0f;     // Amplitude of the motion for each piece
    public Text levelCompleteText;     // Reference to the "Level Complete" UI text
    // public Animator cutsceneAnimator;  // Reference to the cutscene Animator
    public string prefabSavePath = "Assets/Prefabs/";  // Path to save Prefab (in Editor)

    private GameObject currentPiece;   // The currently active piece
    private List<GameObject> placedPieces = new List<GameObject>(); // Track placed pieces
    private int currentPieceIndex = 0; // Track the index of the piece to spawn next
    private int curr = 0;              // Count how many pieces have been spawned
    private bool lastPieceSpawned = false; // Flag to stop spawning after the last piece
    private bool newParentCreated = false;  // Ensure we create the parent object only once
    private GameObject parentObject;    // Store the parent object reference

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

                    // Create a parent object if it hasn't been created yet
                    if (!newParentCreated)
                    {
                        CreateParentForPlacedPieces();
                        newParentCreated = true;  // Ensure the parent is only created once

                        // Trigger the cutscene animation after the last piece is placed
                        // cutsceneAnimator.SetTrigger("StartCutscene");

#if UNITY_EDITOR
                        SaveParentAsPrefab();  // Save the parent object as a Prefab (Editor only)
#endif
                    }
                }
            }
        }
    }

    // Method to spawn a new piece from the array
    private void SpawnPiece()
    {
        // Spawn the next piece from the array
        currentPiece = Instantiate(piecePrefabs[currentPieceIndex], spawnPoint.position, Quaternion.identity);

        // Add the newly spawned piece to the list of placed pieces
        placedPieces.Add(currentPiece);

        // Set random movement properties for the new piece
        PieceMovement pieceMovement = currentPiece.GetComponent<PieceMovement>();
        if (pieceMovement != null)
        {
            if (curr < 2)
            {    
                pieceMovement.x_speed = Random.Range(0.5f, 2.0f);  // Random X 
                pieceMovement.y_speed = Random.Range(0.5f, 2.0f);  // Random Y 
            }
            else if (curr < piecePrefabs.Length - 1)
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

    // Method to create a new parent GameObject and make all placed pieces its children
    private void CreateParentForPlacedPieces()
    {
        // Create a new parent GameObject
		string name = placedPieces[0].name;
		int end = name.IndexOf('_');
        parentObject = new GameObject("PlacedPiecesParent_" + name.Substring(0, end));

        // Loop through each placed piece and set its parent to the new parentObject
        foreach (GameObject piece in placedPieces)
        {
            piece.transform.SetParent(parentObject.transform);
        }

        Debug.Log("All placed pieces have been parented to the new parent object.");
    }

#if UNITY_EDITOR
    // Save the parent object as a Prefab in the Editor
    private void SaveParentAsPrefab()
    {
        if (parentObject == null)
        {
            Debug.LogError("No parent object to save.");
            return;
        }

        // Define the full path to save the prefab
        string fullPath = prefabSavePath + parentObject.name + ".prefab";

        // Use PrefabUtility to save the parent object as a Prefab
        PrefabUtility.SaveAsPrefabAsset(parentObject, fullPath);
        Debug.Log("Parent object saved as prefab at: " + fullPath);
    }
#endif
}
