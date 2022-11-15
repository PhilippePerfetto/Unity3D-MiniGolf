using System;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public Material[] mat; // liste des ciels

    // Ground decorations
    public GameObject[] prefabs;
    public Vector3[] moves = new Vector3[10];
    public Vector3[] rotat = new Vector3[10];

    private void Start()
    {
        if (SceneManager.GetActiveScene().name == "Menu") // sécurité, mais inutile
        {
            ChangeProfile((int)GameManager.Instance.Profile);
        }
    }

    private void UpdateGroundDecoration()
    {
        var gos = GameObject.FindGameObjectsWithTag("groundDecoration");
        int name = 1;
        bool randomModel = false;
        int indexRandomized;

        var index = (int)GameManager.Instance.Profile * 2;

        foreach (var go in gos)
        {
            indexRandomized = randomModel ? index : index + 1;
            var pos = go.transform.position + moves[indexRandomized];

            if (moves[indexRandomized].z >= 49.0f)
            {
                print("trasnform:" + go.transform.position);
                print("     moves:" + moves[indexRandomized]);
                print("     pos:" + pos);
            }

            var newGo = Instantiate(prefabs[indexRandomized], pos, Quaternion.identity);
            newGo.transform.Rotate(rotat[indexRandomized]);
            // newGo.transform.position = pos; // useless

            if (moves[indexRandomized].z >= 49.0f)
                print("         final transform:" + newGo.transform.position);

            newGo.AddComponent(Type.GetType("DontDestroyOnLoad")); // work only on root objects !
            newGo.name = name.ToString();
            newGo.tag = go.tag;
            name++;
            randomModel = !randomModel;

            Destroy(go);
        }
    }

    private void CreateGroundDecoration()
    {
        var gos = GameObject.FindGameObjectsWithTag("groundDecoration");
        foreach (var go in gos) { Destroy(go); }

        int name = 1;
        bool randomModel = false;
        int indexRandomized;

        var index = (int)GameManager.Instance.Profile * 2;
        var maxDeco = 1000;

        for (var i = 0; i < maxDeco; i++)
        {
            var x = UnityEngine.Random.Range(0.0f, 200.0f) - 100.0f;
            var rotY = UnityEngine.Random.Range(0.0f, 360.0f);
            var z = UnityEngine.Random.Range(0.0f, 200.0f) - 100.0f;

            indexRandomized = randomModel ? index : index + 1;
            var pos = moves[indexRandomized] + new Vector3(x, 0.0f, z);

            print("     moves:" + moves[indexRandomized]);
            print("     pos:" + pos);

            var newGo = Instantiate(prefabs[indexRandomized], pos, Quaternion.identity);
            newGo.transform.Rotate(rotat[indexRandomized] + new Vector3(0.0f, rotY, 0.0f));

            print("         final transform:" + newGo.transform.position);

            newGo.AddComponent(Type.GetType("DontDestroyOnLoad")); // work only on root objects !
            newGo.name = name.ToString();
            newGo.tag = "groundDecoration";
            name++;
            randomModel = !randomModel;
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
        // UpdateGroundDecoration();
        CreateGroundDecoration();

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
