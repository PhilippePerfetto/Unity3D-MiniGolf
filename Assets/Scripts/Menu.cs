using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void LaunchGame()
    {
        SceneManager.LoadScene(1);
    }
}
