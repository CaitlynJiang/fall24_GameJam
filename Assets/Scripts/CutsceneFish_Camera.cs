using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutsceneFish_Camera : MonoBehaviour
{

    public Transform fish;
    public float offsetX;

    //private AudioSource backgroundLOne;
    // Start is called before the first frame update
    void Start()
    {
        //backgroundLOne = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;
        pos.x = fish.position.x + offsetX;
      
        transform.position = pos;
    }
}
