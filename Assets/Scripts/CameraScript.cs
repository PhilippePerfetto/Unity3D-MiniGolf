using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public class CameraScript : MonoBehaviour
{
    public GameObject balle;
    public float distance = 3.5f;
    float x = 0.0f, y = 0.0f;
    Quaternion rotation;
    Touch touch;

    void Start()
    {
        x = transform.eulerAngles.y;
        y = transform.eulerAngles.x;
    }

    void LateUpdate()
    {
        // Si on est sur PC/Mac
#if UNITY_EDITOR || UNITY_STANDALONE
        x -= Input.GetAxis("Mouse X") * 3;
#endif

        // Si on est sur mobile
#if UNITY_ANDROID || UNITY_IPHONE
    if (Input.Touches.Length == 1)
    {
        x += Input.GetTouch(0).deltaPosition * 0.1f;
    }
#endif

        if (!EventSystem.current.IsPointerOverGameObject())
        {
            rotation = Quaternion.Euler(y, x, 0);
        }

        var result = rotation * new Vector3(0, balle.transform.position.y / 3f, -distance);
        Vector3 positionCamera = result + balle.transform.position;

        transform.SetPositionAndRotation(positionCamera, rotation);

        if (transform.position.y < 2.5f)
        {
            transform.position = new Vector3(transform.position.x, 2.5f, transform.position.z);
        }
    }
}
