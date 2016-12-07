using UnityEngine;
using System.Collections;

public class PlatformsGenretor : MonoBehaviour {

    public GameObject thePaltform;
    public Transform generationPoint;
    public float distanceBetween;

    private float platformWidth;

    public float distanceBetweenMin;
    public float distanceBetweenMax;

    public ObjectPooler[] theObjectPools;

    private int platformSelector;
    //public GameObject[] thePaltforms;
    private float[] platformWidths;

    private float minHeight;
    public Transform maxHeightPoint;
    private float maxHeight;
    public float maxHeightChange;
    private float heightChange;

    public float randomSpikeThreshold;
    public ObjectPooler spikePool;

    // Use this for initialization
    void Start () {
       // platformWidth = thePaltform.GetComponent<BoxCollider2D>().size.x;

        platformWidths = new float[theObjectPools.Length];

        for(int i = 0; i < theObjectPools.Length; i++)
        {
            platformWidths[i] = theObjectPools[i].pooledObject.GetComponent<BoxCollider2D>().size.x;
        }

       minHeight = transform.position.y;
       maxHeight = maxHeightPoint.position.y;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (transform.position.x < generationPoint.position.x)
        {
            distanceBetween = Random.Range(distanceBetweenMin, distanceBetweenMax);

            platformSelector = Random.Range(0, theObjectPools.Length);

            heightChange = transform.position.y + Random.Range(maxHeightChange, -maxHeightChange);

              if(heightChange > maxHeight)
                {
                   heightChange = maxHeight;
                }
               else if (heightChange < minHeight)
              {
                      heightChange = minHeight;
              }

            transform.position = new Vector3(transform.position.x + (platformWidths[platformSelector] / 2) + distanceBetween, heightChange, transform.position.z);

            //Instantiate(/*thePaltform*/thePaltforms[platformSelector] , transform.position, transform.rotation);

            GameObject newPlatform =  theObjectPools[platformSelector].GetPooledObject();

            newPlatform.transform.position = transform.position;
            newPlatform.transform.rotation = transform.rotation;
            newPlatform.SetActive(true);

            if(Random.Range(0f,100f) < randomSpikeThreshold)
            {
                GameObject newSpike = spikePool.GetPooledObject();

                float spikeXPosition = Random.Range(-platformWidths[platformSelector] / 2f + 1f, platformWidths[platformSelector] / 2f - 1f);

                Vector3 spikePosition = new Vector3(spikeXPosition , 0.5f, 0f);

                newSpike.transform.position = transform.position + spikePosition;
                newSpike.transform.rotation = transform.rotation;
                newSpike.SetActive(true);
            }

           transform.position = new Vector3(transform.position.x + (platformWidths[platformSelector] / 2), transform.position.y, transform.position.z);
        }
	}
}
