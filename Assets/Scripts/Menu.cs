using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public GameObject flower;

    private void Start()
    {
        if (SceneManager.GetActiveScene().name == "Menu") // sécurité, mais inutile
        {
            var gos = GameObject.FindGameObjectsWithTag("tree");
            int name = 1;

            foreach (var go in gos)
            {
                var pos = go.transform.position + new Vector3(0, 0.4f, 0);
                var newGo = Instantiate(flower, pos, Quaternion.identity);
                newGo.AddComponent(Type.GetType("DontDestroyOnLoad")); // work only on root objects !
                newGo.name= name.ToString();
                name++;
                Destroy(go);
            }
        }
    }

    public void LoadLevel(int level)
    {
        SceneManager.LoadScene(level + 2);
    }
}
