using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PanelFin : MonoBehaviour
{
    public TextMeshProUGUI textScore;

    public void BackToMenu() => SceneManager.LoadScene(0);
    public void GoToNextLevel()
    {
        int nextLevel = SceneManager.GetActiveScene().buildIndex + 1;
        if (nextLevel > SceneManager.sceneCountInBuildSettings)
            nextLevel = 0;
        SceneManager.LoadScene(nextLevel);
    }

    public void SetTotalScore()
    {
        textScore.text = "Votre score total : " + GameManager.Score;
    }
}
