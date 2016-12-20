using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement; 

public class DeathMenu : MonoBehaviour {

    public void ExitToMenu()
    {

       SceneManager.LoadScene("Title");
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("Game");
    }

}
