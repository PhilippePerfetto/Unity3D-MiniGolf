using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PanelFin : MonoBehaviour
{
    public TextMeshProUGUI textScore;

    public void BackToMenu()
    {
        Time.timeScale = 1f;
        GameManager.Instance.PanelPauseAndFire.SetActive(false);
        GameManager.Instance.PanelPause.SetActive(false);
        GameManager.Instance.PanelFin.SetActive(false);
        SceneManager.LoadScene(1);
    }

    public void GoToNextLevel()
    {
        int nextLevel = SceneManager.GetActiveScene().buildIndex + 1;
        if (nextLevel > SceneManager.sceneCountInBuildSettings)
            nextLevel = 2;

        UnlockNextLevel(nextLevel);
        SceneManager.LoadScene(nextLevel);
    }

    public void UnlockNextLevel(int level)
    {
        int lastUnlockedLevel = Math.Max(PlayerPrefs.GetInt("lastLevel"), level);

        PlayerPrefs.SetInt("lastLevel", lastUnlockedLevel - 1);
    }

    public void SetTotalScore()
    {
        textScore.text = "Votre score total : " + GameManager.Instance.Score;
    }

    public void QuitApp()
    {
        Application.Quit();
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.N))
        {
            GoToNextLevel();
        }
    }
}
