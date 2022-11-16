using System;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int Score = 0;
    public int NbShots = 0;

    public enum Profiles { Lohan, Emma, Marc, Marina };
    public Profiles Profile = Profiles.Lohan;

    private static GameManager _instance;
    public static GameManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<GameManager>();
            }
            return _instance;
        }
    }

    private GameObject ball;
    private GameObject rotatingCamera;
    private IEnumerable<GameObject> menuButtons;
    private IEnumerable<GameObject> profileButtons;

    private GameObject canvasPause;
    private GameObject shotButton;
    private GameObject fireBar;
    private GameObject panelFin;
    private GameObject panelPauseAndFire;
    private GameObject panelPause;
    private TextMeshProUGUI textNbShots;
    private GameObject pushToPlayText;

    public GameObject CanvasPause { get => canvasPause; set => canvasPause = value; }
    public GameObject ShotButton { get => shotButton; set => shotButton = value; }
    public GameObject FireBar { get => fireBar; set => fireBar = value; }
    public GameObject PanelFin { get => panelFin; set => panelFin = value; }
    public GameObject PanelPauseAndFire { get => panelPauseAndFire; set => panelPauseAndFire = value; }
    public GameObject PanelPause { get => panelPause; set => panelPause = value; }
    public TextMeshProUGUI TextNbShots { get => textNbShots; set => textNbShots = value; }
    public GameObject PushToPlayText { get => pushToPlayText; set => pushToPlayText = value; }

    public int NbLevels => PlayerPrefs.GetInt("lastLevel_Lohan") + PlayerPrefs.GetInt("lastLevel_Emma") + PlayerPrefs.GetInt("lastLevel_Marc") + PlayerPrefs.GetInt("lastLevel_Marina");

    public string PrefKey() => "lastLevel_" + Profile;

    public void UnlockNextLevel(int level)
    {
        int lastUnlockedLevel = Math.Max(PlayerPrefs.GetInt(PrefKey()), level);

        PlayerPrefs.SetInt(PrefKey(), lastUnlockedLevel - 1);
    }

    public int GetNetxLevel() => PlayerPrefs.GetInt(PrefKey());

    public void SceneChanged()
    {
        NbShots = 0;

        ball = null;
        rotatingCamera = null;
        menuButtons = null;
        profileButtons = null;
    }

    public GameObject GetInSceneBall()
    {
        if (ball == null)
        {
            ball = GameObject.Find("Ball_HD");
        }

        return ball;
    }

    public GameObject GetInSceneRotatingCamera()
    {
        print("GetInSceneRotatingCamera");
        if (rotatingCamera == null)
        {
            print("null => search");
            rotatingCamera = GameObject.Find("RotatingCamera");
        }
        print(rotatingCamera.GetHashCode());

        return rotatingCamera;
    }

    public IEnumerable<GameObject> GetInSceneMenuButtons()
    {
        if (menuButtons == null)
        {
            print("GetInSceneMenuButtons : null => search");
            menuButtons = GameObject.FindGameObjectsWithTag("menuButtons").ToList().OrderBy(x => int.Parse(x.name[8..]));
            print(menuButtons.Count());
        }

        return menuButtons;
    }

    public IEnumerable<GameObject> GetInSceneProfileButtons()
    {
        if (profileButtons == null)
        {
            print("GetInSceneProfileButtons : null => search");
            profileButtons = GameObject.FindGameObjectsWithTag("profileButtons").ToList().OrderBy(x => int.Parse(x.name[10..]));
            print(profileButtons.Count());
        }

        return profileButtons;
    }
}
