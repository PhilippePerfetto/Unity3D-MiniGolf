using UnityEngine;

public class Rotate : MonoBehaviour
{
    public float speed;

    void Update()
    {
        transform.Rotate(Vector3.forward * Time.deltaTime * speed);
    }
}
