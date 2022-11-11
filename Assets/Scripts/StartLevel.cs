using UnityEngine;

public class StartLevel : MonoBehaviour
{
    public GameObject gameIHM;
    public GameObject animCam;

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space)
            || Input.GetMouseButtonUp(0)) // devrait fonctionner sur mobile
        {
            gameIHM.SetActive(true);
            animCam.SetActive(false);
            this.gameObject.SetActive(false);
        }
    }
}
