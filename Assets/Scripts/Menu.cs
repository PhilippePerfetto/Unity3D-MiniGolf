using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public GameObject prefabButton;

    public void LaunchGame()
    {
        SceneManager.LoadScene(2);
    }

    public void LoadLevel(int level)
    {
        SceneManager.LoadScene(level + 2);
    }
}
