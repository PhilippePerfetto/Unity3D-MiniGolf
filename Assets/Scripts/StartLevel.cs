using UnityEngine;

public class StartLevel : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space)
            || Input.GetMouseButtonUp(0)) // devrait fonctionner sur mobile
        {
            GameManager.Instance.PanelPauseAndFire.SetActive(true);
            GameManager.Instance.GetInSceneRotatingCamera().SetActive(false);
            this.gameObject.SetActive(false);
        }
    }
}
