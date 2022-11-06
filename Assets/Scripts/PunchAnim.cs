using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PunchAnim : MonoBehaviour
{
    public float punchScale = 1.0f;
    // Start is called before the first frame update
    void Start()
    {
        iTween.PunchScale(gameObject, 
            iTween.Hash(
                "looptype", iTween.LoopType.loop, 
                "amount", new Vector3(transform.localScale.x * punchScale, transform.localScale.y * punchScale, transform.localScale.z * punchScale)
                ));
    }
}
