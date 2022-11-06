using UnityEngine;

public class RandomSky : MonoBehaviour
{
    public Material[] mat; // liste des ciels

    void Start()
    {
        int random = Random.Range(0, mat.Length);
        RenderSettings.skybox = mat[random];
    }

    void Update()
    {
        RenderSettings.skybox.SetFloat("_Rotation", -2.5f * Time.time);
    }
}
