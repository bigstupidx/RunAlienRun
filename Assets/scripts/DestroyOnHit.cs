﻿using UnityEngine;
using System.Collections;

public class DestroyOnHit : MonoBehaviour
{

    public GameObject platformDestructionPoint;


    void Start()
    {
        platformDestructionPoint = GameObject.Find("PlatformDestructionPoint");
    }

    void Update()
    {
        if (transform.position.x < platformDestructionPoint.transform.position.x)
        {
            //Destroy(gameObject);

              gameObject.SetActive(false);
        }
    }
}
