using System;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public Material[] mat; // liste des ciels
    public GameObject flower;

    private void Start()
    {
        if (SceneManager.GetActiveScene().name == "Menu") // sécurité, mais inutile
        {
            UpdateProfileButtons((int)GameManager.Instance.Profile);
            UpdateLevelButtons();

            ReplaceTrees();
        }
    }

    private void ReplaceTrees()
    {
        var gos = GameObject.FindGameObjectsWithTag("tree");
        int name = 1;

        foreach (var go in gos)
        {
            var pos = go.transform.position + new Vector3(0, 0.4f, 0);
            var newGo = Instantiate(flower, pos, Quaternion.identity);
            newGo.AddComponent(Type.GetType("DontDestroyOnLoad")); // work only on root objects !
            newGo.name = name.ToString();
            name++;
            Destroy(go);
        }
    }

    public void LoadLevel(int level)
    {
        SceneManager.LoadScene(level + 2);
    }

    public void ChangeProfile(int profile)
    {
        GameManager.Instance.Profile = (GameManager.Profiles)profile;
        UpdateProfileButtons(profile);
        UpdateLevelButtons();

        RenderSettings.skybox = mat[profile];
    }

    public void UpdateProfileButtons(int profile)
    {
        var btns = GameManager.Instance.GetInSceneProfileButtons();

        foreach (var btn in btns)
            btn.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);

        btns.ElementAt(profile).transform.localScale = new Vector3(1f, 1f, 1f);
    }

    public void UpdateLevelButtons()
    {
        var btns = GameManager.Instance.GetInSceneMenuButtons();

        int level = Math.Max(1, GameManager.Instance.GetNetxLevel());

        for (int i = level; i < btns.Count(); i++)
            btns.ElementAt(i).GetComponent<Button>().interactable = false;

        for (int i = 0; i < level; i++)
            btns.ElementAt(i).GetComponent<Button>().interactable = true;
    }
}
