using UnityEngine;

public class BubbleHandler : MonoBehaviour
{
    public float minDesiredScale;
    public float maxDesiredScale;  // The desired scale
    private Vector3 initialScale;
    private Vector3 targetScale;
    public float growthFactor;
    public float scaleSpeed;
    public GameObject Pop;
    private float randScale;

    public Vector3 currentScale;

    void Start()
    {
        
        // Set the scale immediately after instantiation
        int scaleNum = Random.Range(1,4);
        
        
        if(scaleNum == 1)
        {
            randScale = 0.1f;
        }
        if(scaleNum == 2)
        {

            randScale = 0.3f;
        }
        if (scaleNum == 3)
        {
            randScale = 0.5f;
        }
        
        transform.localScale = new Vector3(randScale, randScale, randScale);
        initialScale = transform.localScale;
        targetScale = new Vector3(initialScale.x + growthFactor, initialScale.y + growthFactor, initialScale.z + growthFactor);
    }
    private void Update()
    {
        // Gradually scale the object toward the target scale
        transform.localScale = Vector3.Lerp(transform.localScale, targetScale, scaleSpeed * Time.deltaTime);

        // Optionally, stop scaling when you reach the target scale (with a small threshold)
        if (Vector3.Distance(transform.localScale, targetScale) < 0.08f)
        {
            transform.localScale = targetScale;  // Snap to the final scale
            currentScale = new Vector3(targetScale.x-0.3f, targetScale.y-0.3f, targetScale.z-0.3f);
            GameObject thisPop = Instantiate(Pop, transform.position, Quaternion.identity);
            thisPop.transform.localScale = currentScale;
            Destroy(gameObject);
        }
    }
}

