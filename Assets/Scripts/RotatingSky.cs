using UnityEngine;

public class RotatingSky : MonoBehaviour
{
    void Update()
    {
        RenderSettings.skybox.SetFloat("_Rotation", -2.5f * Time.time);
    }
}
