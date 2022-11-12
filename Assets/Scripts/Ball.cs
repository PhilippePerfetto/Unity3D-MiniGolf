using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ball : MonoBehaviour
{
    public GameObject winParticles;
    public TextMeshProUGUI text;
    public Shot shotScript;
    public GameObject panelFin;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("fall"))
        {
            SFXManager.Instance.PlaySfxById(2);
            StartCoroutine(nameof(ReloadLevelAfterSeconds));
        }
        else if (other.gameObject.CompareTag("fin"))
        {
            GameManager.Score += Math.Max(0, 10 - shotScript.nbShots) * 100;
            Instantiate(winParticles, transform.position, Quaternion.identity);
            SFXManager.Instance.PlaySfxById(0);
            text.text = $"Fini en {shotScript.nbShots} coups";

            var scr = panelFin.GetComponent<PanelFin>();
            scr.SetTotalScore();
            panelFin.SetActive(true);
        }
    }

    IEnumerator ReloadLevelAfterSeconds()
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
