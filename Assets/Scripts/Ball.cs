using UnityEngine;
using UnityEngine.SceneManagement;

public class Ball : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "fall")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        else if (other.gameObject.tag == "fin")
        {
            int nextLevel = SceneManager.GetActiveScene().buildIndex + 1;
            if (nextLevel >= SceneManager.sceneCount)
                nextLevel = 0;
            SceneManager.LoadScene(nextLevel);
        }
    }
}
