using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shot : MonoBehaviour
{
    public RectTransform powerBar;
    public GameObject ball;
    bool powerActivated = false;
    bool canShot = true;
    public float shotPowerMultiplier;

    private void Update()
    {
        if (Input.GetMouseButtonUp(1)) // Right
        {
            HandleShot();
        }
    }

    public void HandleShot()
    {
        if (canShot)
        {
            if (powerActivated)
            {
                powerActivated = !powerActivated;
                ShotTheBall();
            }
            else
            {
                powerActivated = !powerActivated;
                ActivatePowerBar();
            }
        }
    }

    void ActivatePowerBar()
    {
        StartCoroutine(nameof(AnimatePowerBar));
    }

    void ShotTheBall()
    {
        StopAllCoroutines();

        float shotPower = powerBar.localScale.x * shotPowerMultiplier;
        ball.GetComponent<Rigidbody>().AddForce(Camera.main.transform.forward * shotPower);
    }

    IEnumerator AnimatePowerBar()
    {
        float val = 0.1f;

        while (powerActivated)
        {
            yield return new WaitForSeconds(0.1f);
            powerBar.localScale = new Vector3(powerBar.localScale.x - val, powerBar.localScale.y, powerBar.localScale.z);

            if (powerBar.localScale.x < 0.2f)
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
