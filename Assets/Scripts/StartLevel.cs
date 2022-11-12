using UnityEngine;

public class StartLevel : MonoBehaviour
{
    public GameObject powerIHM;
    public GameObject fireIHM;
    public GameObject animCam;

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space)
            || Input.GetMouseButtonUp(0)) // devrait fonctionner sur mobile
        {
            powerIHM.SetActive(true);
            fireIHM.SetActive(true);
            animCam.SetActive(false);
            this.gameObject.SetActive(false);
        }
    }
}
