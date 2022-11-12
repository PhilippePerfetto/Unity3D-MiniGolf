using UnityEngine;
using UnityEngine.UI;

public class SetVolume : MonoBehaviour
{
    private void Start()
    {
        if (PlayerPrefs.HasKey("volume"))
        {
            var val = PlayerPrefs.GetFloat("volume");
            print(val);
            GetComponent<Slider>().value = val;
            // SetToComponent(val);
        }
    }

    public void SetMusicVolume()
    {
        float val = GetComponent<Slider>().value;
        PlayerPrefs.SetFloat("volume", val);

        SetToComponent(val);
    }

    private static void SetToComponent(float val)
    {
        var music = GameObject.Find("BackgroundMusic");
        music.GetComponent<AudioSource>().volume = val;
    }
}
