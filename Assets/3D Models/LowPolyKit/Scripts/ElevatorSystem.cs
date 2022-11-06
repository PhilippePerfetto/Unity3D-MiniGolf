using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorSystem : MonoBehaviour
{
    bool isUp = false;
    Animation anim;

    private void Start()
    {
        anim = transform.parent.GetComponent<Animation>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "Character_1")
        {
            if (isUp)
            {
                anim.Play("ElevatorGoDownAnimation");
            }
            else
            {
                anim.Play("ElevatorGoUpAnimation");
            }
            isUp = !isUp;
        }
    }
}
