using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

public void PlayGame()
    {
        SceneManager.LoadScene("Flappy Bird Scene");
    }

public void ExitGame()
    {
        Application.Quit();
    }
}

