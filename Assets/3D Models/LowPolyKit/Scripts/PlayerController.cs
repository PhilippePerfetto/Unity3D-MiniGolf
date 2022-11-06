using UnityEngine;

public class PlayerController : MonoBehaviour
{
    #region Private Members

    private Animator _animator;

    private CharacterController _characterController;

    private float Gravity = 20.0f;

    private Vector3 _moveDirection = Vector3.zero;

    #endregion

    #region Public Members

    public float Speed = 5.0f;

    public float RotationSpeed = 240.0f;

    public float JumpSpeed = 7.0f;

    #endregion

    void Start()
    {
        _animator = GetComponent<Animator>();
        _characterController = GetComponent<CharacterController>();
    }


    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 camForward_Dir = Vector3.Scale(Camera.main.transform.forward, new Vector3(1, 0, 1)).normalized;
        Vector3 move = v * camForward_Dir + h * Camera.main.transform.right;

        if (move.magnitude > 1f) move.Normalize();

        move = transform.InverseTransformDirection(move);

        float turnAmount = Mathf.Atan2(move.x, move.z);

        transform.Rotate(0, turnAmount * RotationSpeed * Time.deltaTime, 0);

        if (_characterController.isGrounded)
            {
                _moveDirection = transform.forward * move.magnitude;
                _moveDirection *= Speed;

                if (Input.GetButton("Jump"))
                {
                    _moveDirection.y = JumpSpeed;
                }
            }

            _moveDirection.y -= Gravity * Time.deltaTime;
            _characterController.Move(_moveDirection * Time.deltaTime);

        if(_moveDirection.x != 0 || _moveDirection.z != 0)
        {
            _animator.SetBool("isWalking", true);
        }
        else
        {
            _animator.SetBool("isWalking", false);
        }
    }
    
}
