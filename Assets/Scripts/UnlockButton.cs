using System;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class UnlockButton : MonoBehaviour
{
    void Start()
    {
        int level = PlayerPrefs.GetInt("lastLevel");

        int btnLevel = 0;
        try
        {
            string nb = gameObject.name.Substring(8);

            btnLevel = int.Parse(nb);
        }
        catch (Exception) { print("failed to parse nb in : " + gameObject.name); }

        if (btnLevel <= level)
        {
            GetComponent<Button>().interactable = true;
        }
    }
}
