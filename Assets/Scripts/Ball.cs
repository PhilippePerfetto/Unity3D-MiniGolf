using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ball : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "fall")
        {
            SFXManager.Instance.PlaySfxById(2);
            StartCoroutine(nameof(ReloadLevelAfterSeconds));
        }
        else if (other.gameObject.tag == "fin")
        {
            SFXManager.Instance.PlaySfxById(0);
            int nextLevel = SceneManager.GetActiveScene().buildIndex + 1;
            if (nextLevel >= SceneManager.sceneCount)
                nextLevel = 0;
            SceneManager.LoadScene(nextLevel);
        }
    }

    IEnumerator ReloadLevelAfterSeconds()
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
