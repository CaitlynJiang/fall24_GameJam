using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutsceneFish_Camera : MonoBehaviour
{

    public Transform fish;
    public float offsetX;
    public GameObject playerFish;

    //private AudioSource backgroundLOne;
    // Start is called before the first frame update
    void Start()
    {
        //backgroundLOne = GetComponent<AudioSource>();
        Vector3 fishPosition = new Vector3(transform.position.x, transform.position.y, 0);
        GameObject thisFish = Instantiate(playerFish, transform.position, Quaternion.identity);
        fish = thisFish.transform;

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;
        pos.x = fish.position.x + offsetX;
      
        transform.position = pos;
    }
}
