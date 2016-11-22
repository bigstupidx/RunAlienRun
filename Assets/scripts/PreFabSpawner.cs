using UnityEngine;
using System.Collections;

public class PreFabSpawner : MonoBehaviour {

    private float nextSpawn = 0;
    public Transform prefabSpawn;
    public AnimationCurve spawnCurve;
    public float curveLengthInSeconds = 30f;
    public float jitter = 0.25f;
    private float startTime;


	// Use this for initialization
	void Start () {
        startTime = Time.time;
	}
	
	// Update is called once per frame
	void Update ()
    {
	    if(Time.time > nextSpawn)
        {
            Instantiate(prefabSpawn, transform.position, Quaternion.identity);
            //nextSpawn = Time.time + spawnRate + Random.Range(0, randomDelay);

            float curvePos = (Time.time - startTime) / curveLengthInSeconds;
            if(curvePos > 1f)
            {
                curvePos = 1f;
                startTime = Time.time;
            }

            nextSpawn = Time.time + spawnCurve.Evaluate(curvePos) + Random.Range(-jitter, jitter);
        }
	}
}
