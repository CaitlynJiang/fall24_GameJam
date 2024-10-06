using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopHandler : MonoBehaviour
{

    private float lifeTimer;

    // Start is called before the first frame update
    void Start()
    {
        lifeTimer = 1f;

    }

    // Update is called once per frame
    void Update()
    {
        lifeTimer = lifeTimer - Time.deltaTime;
        if (lifeTimer <= 0)
        {
            Destroy(gameObject);
        }
        
    }
}
