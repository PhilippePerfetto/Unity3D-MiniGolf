using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFollow : MonoBehaviour
{
    public Transform PlayerTransform;

    private Vector3 _cameraOffset;

    [Range(0.01f, 1.0f)]
    public float SmoothFactor = 0.5f;

    public bool RotateAroundPlayer = true;

    public float RotationsSpeed = 5.0f;

    public float CameraPitchMin = 1.5f;

    public float CameraPitchMax = 6.5f;

    void Start()
    {
        _cameraOffset = transform.position - PlayerTransform.position;
    }

    private bool IsRotateActive
    {
        get
        {
            if (!RotateAroundPlayer)
                return false;

            return false;
        }
    }

    void LateUpdate()
    {
        if (IsRotateActive)
        {

            float h = Input.GetAxis("Mouse X") * RotationsSpeed;
            float v = Input.GetAxis("Mouse Y") * RotationsSpeed;

            Quaternion camTurnAngle = Quaternion.AngleAxis(h, Vector3.up);

            Quaternion camTurnAngleY = Quaternion.AngleAxis(v, transform.right);

            Vector3 newCameraOffset = camTurnAngle * camTurnAngleY * _cameraOffset;

            if (newCameraOffset.y < CameraPitchMin || newCameraOffset.y > CameraPitchMax)
            {
                newCameraOffset = camTurnAngle * _cameraOffset;
            }

            _cameraOffset = newCameraOffset;
        }

        Vector3 newPos = PlayerTransform.position + _cameraOffset;

        transform.position = Vector3.Slerp(transform.position, newPos, SmoothFactor);

        if (RotateAroundPlayer)
            transform.LookAt(PlayerTransform);
    }
}
