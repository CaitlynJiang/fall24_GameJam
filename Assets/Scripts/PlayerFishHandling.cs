using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerFishHandling : MonoBehaviour
{
    private BGComponentMover bgMover;
    
    // Start is called before the first frame update
    void Start()
    {

         
        transform.rotation = Quaternion.Euler(0, 0, 90);
        Vector3 currentScale = transform.localScale;
        currentScale.y = -currentScale.y;  // Flip along Y-axis
        transform.localScale = currentScale;

        foreach (Transform child in transform)
        {
            // Check if the child has a Renderer component
            Renderer childRenderer = child.GetComponent<Renderer>();
            if (childRenderer != null)
            {
                // Set the sorting layer by name
                childRenderer.sortingLayerName = "MC";
            }
        }


        //Set as object for BGComponentMovmeent
        GameObject overlay = GameObject.Find("Cutscene1_overlay");
        bgMover = overlay.GetComponent<BGComponentMover>();
        bgMover.player = transform.gameObject;
        GameObject fg1 = GameObject.Find("cutscene1_foreground1");
        bgMover = fg1.GetComponent<BGComponentMover>();
        bgMover.player = transform.gameObject;
        GameObject fg2 = GameObject.Find("cutscene1_foreground2");
        bgMover = fg2.GetComponent<BGComponentMover>();
        bgMover.player = transform.gameObject;
     
      

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
