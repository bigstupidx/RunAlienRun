using UnityEngine;
using System.Collections;
using System;

public class GameManagaer : MonoBehaviour {
    
    public static GameManagaer Instance { set; get; }

    public Transform platformGeneretor;
    private Vector3 platformStartPoint;

    public beeContorller thePlayer;
    private Vector3 playerStartPoint;

    private DestroyOnHit[] platformList;

    private ScoreManager theScoreManager;

    public DeathMenu theDeathScreen;



    // Use this for initialization
    void Start ()
    {
        platformStartPoint = platformGeneretor.position;
        playerStartPoint = thePlayer.transform.position;

        theScoreManager = FindObjectOfType<ScoreManager>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void RestartGame()
    {

        theScoreManager.scoreIncreasing = false;
        thePlayer.gameObject.SetActive(false);

        theDeathScreen.gameObject.SetActive(true);

        //StartCoroutine("RestartGameCo");
    }

    public void Reset()
    {
        theDeathScreen.gameObject.SetActive(false);
        platformList = FindObjectsOfType<DestroyOnHit>();
        for (int i = 0; i < platformList.Length; i++)
        {
            platformList[i].gameObject.SetActive(false);
        }

        thePlayer.transform.position = playerStartPoint;
        platformGeneretor.position = platformStartPoint;
        thePlayer.gameObject.SetActive(true);

        theScoreManager.scoreCount = 0;
        theScoreManager.scoreIncreasing = true;
    }

    /*public IEnumerator RestartGameCo()
    {
        theScoreManager.scoreIncreasing = false;
        thePlayer.gameObject.SetActive(false);
        yield return new WaitForSeconds(0.5f);
        platformList = FindObjectsOfType<DestroyOnHit>();
        for(int i = 0; i < platformList.Length; i++)
        {
            platformList[i].gameObject.SetActive(false);
        }
        
        thePlayer.transform.position = playerStartPoint;
        platformGeneretor.position = platformStartPoint;
        thePlayer.gameObject.SetActive(true);

        theScoreManager.scoreCount = 0;
        theScoreManager.scoreIncreasing = true;
    }*/
}
