using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shot : MonoBehaviour
{
    public RectTransform powerBar;
    public GameObject ball;
    public GameObject guide;
    bool powerActivated = false;
    bool canShot = true;
    bool canCheckSpeed = false;
    public float shotPowerMultiplier;
    public int nbShots = 0;

    private void Update()
    {
        if (Input.GetMouseButtonUp(1)) // Right
        {
            HandleShot();
        }

        if (canCheckSpeed && ball.GetComponent<Rigidbody>().velocity.magnitude < 0.2f)
        {
            canShot = true;
            GetComponent<Button>().interactable = canShot;
        }
    }

    IEnumerator ActivateSpeedCheck()
    {
        yield return new WaitForSeconds(1.0f);
        canCheckSpeed = true;
    }

    public void HandleShot()
    {
        if (canShot)
        {
            if (powerActivated)
            {
                powerActivated = !powerActivated;
                guide.SetActive(false);
                ShotTheBall();
                canShot = false;
                GetComponent<Button>().interactable = canShot;
                SFXManager.Instance.PlaySfxById(3);
            }
            else
            {
                powerActivated = !powerActivated;
                guide.SetActive(true);
                ActivatePowerBar();
            }
        }
    }

    void ActivatePowerBar()
    {
        SFXManager.Instance.PlaySfxById(4);
        StartCoroutine(nameof(AnimatePowerBar));
    }

    void ShotTheBall()
    {
        SFXManager.Instance.PlaySfxById(1);
        StopAllCoroutines();

        float shotPower = powerBar.localScale.x * shotPowerMultiplier;
        ball.GetComponent<Rigidbody>().AddForce(Camera.main.transform.forward * shotPower);
        nbShots++;
        StartCoroutine(nameof(ActivateSpeedCheck));
    }

    IEnumerator AnimatePowerBar()
    {
        float val = 0.1f;

        while (powerActivated)
        {
            yield return new WaitForSeconds(0.15f);
            powerBar.localScale = new Vector3(powerBar.localScale.x - val, powerBar.localScale.y, powerBar.localScale.z);

            if (powerBar.localScale.x < 0.1f)
            {
                val = -0.1f;
            }
            else if (powerBar.localScale.x > 0.9f)
            {
                val = 0.1f;
            }
        }
    }
}
