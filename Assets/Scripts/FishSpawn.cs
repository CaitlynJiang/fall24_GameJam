using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishSpawn : MonoBehaviour
{
    public GameObject playerFish;
    public GameObject fish;
    // Start is called before the first frame update
    void Start()
    {
        Vector3 fishPosition = new Vector3(transform.position.x, transform.position.y, 0);
        GameObject thisFish = Instantiate(playerFish, transform.position, Quaternion.identity);
        fish = thisFish;

        fish.transform.rotation = Quaternion.Euler(0, 0, 90);
        Vector3 currentScale = fish.transform.localScale;
        currentScale.y = -currentScale.y;  // Flip along Y-axis
        fish.transform.localScale = currentScale;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
