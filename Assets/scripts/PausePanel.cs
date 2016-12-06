using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class PausePanel : MonoBehaviour
{ 

    public GameObject pauseMenu;

    public void PauseGame()
    {
        Time.timeScale = 0f;
        pauseMenu.SetActive(true);
    }

    public void ResumeGame()
    {
        Time.timeScale = 1f;
        pauseMenu.SetActive(false);
    }

    public void ExitToMenu()
    {
        Time.timeScale = 1f;
        Application.LoadLevel("Tittle");
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
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