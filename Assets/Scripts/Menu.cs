using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public GameObject flower;

    private void Start()
    {
        if (SceneManager.GetActiveScene().name == "Menu")
        {
            print("removing GOs");
            var gos = GameObject.FindGameObjectsWithTag("tree");

            foreach (var go in gos)
            {
                var pos = go.transform.position + new Vector3(0, 0.4f, 0);
                var newGo = Instantiate(flower, pos, Quaternion.identity, gameObject.transform.parent);
                newGo.AddComponent(Type.GetType("DontDestroyOnLoad"));
                Destroy(go);
            }
        }
    }

    public void LaunchGame()
    {
        SceneManager.LoadScene(2);
    }

    public void LoadLevel(int level)
    {
        SceneManager.LoadScene(level + 2);
    }
}
