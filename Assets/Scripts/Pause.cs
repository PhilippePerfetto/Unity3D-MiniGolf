using UnityEngine;

public class Pause : MonoBehaviour
{
    bool isPaused = false;
    public GameObject pauseMenu;

    public void SetPauseState()
    {
        if (isPaused)
        {
            Time.timeScale = 1f;
        }
        else
        {
            Time.timeScale = 0f;
        }

        isPaused = !isPaused;
        pauseMenu.SetActive(isPaused);
    }
}
