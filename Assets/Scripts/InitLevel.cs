using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InitLevel : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var all = GetAllObjectsOnlyInScene();
        GameManager.Instance.CanvasPause = all.First(x => x.name == "CanvasPause");
        GameManager.Instance.FireBar = all.First(x => x.name == "FireBar");
        GameManager.Instance.ShotButton = all.First(x => x.name == "ShotButton");
        GameManager.Instance.PanelFin = all.First(x => x.name == "PanelFin");
        GameManager.Instance.TextNbShots = all.First(x => x.name == "TextNbShots").GetComponent<TextMeshProUGUI>();
        GameManager.Instance.PanelPauseAndFire = all.First(x => x.name == "PanelPauseAndFire");
        GameManager.Instance.PanelPause = all.First(x => x.name == "PanelPause");
        GameManager.Instance.PushToPlayText = all.First(x => x.name == "PushToPlayText");

        SceneManager.activeSceneChanged += SceneManager_activeSceneChanged;
    }

    private void SceneManager_activeSceneChanged(Scene arg0, Scene arg1)
    {
        print("Before scene change...");
        GameManager.Instance.SceneChanged();
        print("     After scene change");

        if (SceneManager.GetActiveScene().name.StartsWith("MyLevel"))
        {
            /*
            print("list :");
            foreach (var go in all.Select(x => x))
            {
                print("\t" + go?.name);
            }*/
            GameManager.Instance.CanvasPause.SetActive(true);
            GameManager.Instance.PanelFin.SetActive(false);
            GameManager.Instance.PanelPauseAndFire.SetActive(false);
            GameManager.Instance.PushToPlayText.SetActive(true);
        }
    }
    /*
    public GameObject FindObject(string name)
    {
        Transform[] trs = GetComponentsInChildren<Transform>(true);
        foreach (Transform t in trs)
        {
            if (t.name == name)
            {
                return t.gameObject;
            }
        }
        return null;
    }
    */
    List<GameObject> GetAllObjectsOnlyInScene()
    {
        List<GameObject> objectsInScene = new List<GameObject>();

        foreach (GameObject go in Resources.FindObjectsOfTypeAll(typeof(GameObject)) as GameObject[])
        {
            // if (!EditorUtility.IsPersistent(go.transform.root.gameObject) && !(go.hideFlags == HideFlags.NotEditable || go.hideFlags == HideFlags.HideAndDontSave))
                objectsInScene.Add(go);
        }

        return objectsInScene;
    }

    /*
    List<GameObject> GetNonSceneObjects()
    {
        List<GameObject> objectsInScene = new List<GameObject>();

        foreach (GameObject go in Resources.FindObjectsOfTypeAll(typeof(GameObject)) as GameObject[])
        {
            if (EditorUtility.IsPersistent(go.transform.root.gameObject) && !(go.hideFlags == HideFlags.NotEditable || go.hideFlags == HideFlags.HideAndDontSave))
                objectsInScene.Add(go);
        }

        return objectsInScene;
    }

    List<UnityEngine.Object> GetSceneObjectsNonGeneric()
    {
        List<UnityEngine.Object> objectsInScene = new List<UnityEngine.Object>();

        foreach (UnityEngine.Object go in Resources.FindObjectsOfTypeAll(typeof(UnityEngine.Object)) as UnityEngine.Object[])
        {
            GameObject cGO = go as GameObject;
            if (cGO != null && !EditorUtility.IsPersistent(cGO.transform.root.gameObject) && !(go.hideFlags == HideFlags.NotEditable || go.hideFlags == HideFlags.HideAndDontSave))
                objectsInScene.Add(go);
        }

        return objectsInScene;
    }*/
}
