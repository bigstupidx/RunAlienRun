using UnityEngine;
using System.Collections;

public class ScrollingBG : MonoBehaviour {

    public float speed = 0.1f;
	
	// Update is called once per frame
	void Update ()
    {
        Vector2 offest = new Vector2(Time.time * speed, 0);

        GetComponent<Renderer>().material.mainTextureOffset = offest;
	}
}
