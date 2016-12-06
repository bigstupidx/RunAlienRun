using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement; 

public class DeathMenu : MonoBehaviour {

    public void ExitToMenu()
    {
        // Reload the level
        Application.LoadLevel("Tittle");
    }

    public void RestartGame()
    {
        Application.LoadLevel("Game");
    }

}
