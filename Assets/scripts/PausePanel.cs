using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class PausePanel : MonoBehaviour
{

    public GameObject pauseButton, pausePanel;

    private bool isPaused;


    public void OnPause()
    {
        pausePanel.SetActive(true);
        pauseButton.SetActive(false);
        Time.timeScale = 0;
    }

    public void OnUnPause()
    {
        pausePanel.SetActive(false);
        pauseButton.SetActive(true);
        Time.timeScale = 1;
    }

    public void PauseGame()
    {
        pausePanel.SetActive(!pausePanel.activeSelf);
        isPaused = pausePanel.activeSelf;
    }

    public void NewGame()
    {
        isPaused = false;
        Application.LoadLevel("Game");
    }

    /*public void ShowAd()
    {
        if (Advertisement.IsReady())
        {
            Advertisement.Show("video", new ShowOptions() { resultCallback = HandleAdResult });
        }
    }/*

   /* private void HandleAdResult(ShowResult result)
    {
        switch (result)
        {
            case ShowResult.Skipped:
                Debug.Log("Player did not fully watch the ad");
                break;

            case ShowResult.Failed:
                Debug.Log("Player failed to launch the ad");
                break;
        }
    }*/
}