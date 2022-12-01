using UnityEngine.SceneManagement;
using UnityEngine;

public class OnClickEvents : MonoBehaviour
{
    public GameObject pauseMenuScreen;

    public void PauseGame()
    {
        Time.timeScale = 0;
        pauseMenuScreen.SetActive(true);
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
        pauseMenuScreen.SetActive(false);
    }

    public void GoToMainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Main Menu");
    }
    public void LoadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void LoadNextLevel()
    {
        if (SceneManager.
            GetActiveScene().buildIndex < 6)
            SceneManager.LoadScene(SceneManager.
                GetActiveScene().buildIndex + 1);
        else
        {
            SceneManager.LoadScene(0);
        }
    }
}
