using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ball : MonoBehaviour
{
    public GameObject winParticles;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("fall"))
        {
            SFXManager.Instance.PlaySfxById(2);
            GameManager.Instance.PanelPauseAndFire.SetActive(false);
            StartCoroutine(nameof(ReloadLevelAfterSeconds));
        }
        else if (other.gameObject.CompareTag("fin"))
        {
            GameManager.Instance.Score += Math.Max(0, 10 - GameManager.Instance.NbShots) * 100;
            Instantiate(winParticles, transform.position, Quaternion.identity);
            SFXManager.Instance.PlaySfxById(0);
            GameManager.Instance.TextNbShots.text = $"Fini en {GameManager.Instance.NbShots} coups";

            GameManager.Instance.PanelFin.GetComponent<PanelFin>().SetTotalScore();
            GameManager.Instance.PanelFin.SetActive(true);
            GameManager.Instance.PanelPauseAndFire.SetActive(false);
        }
    }

    IEnumerator ReloadLevelAfterSeconds()
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
