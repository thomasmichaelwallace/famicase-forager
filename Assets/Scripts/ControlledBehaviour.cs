using Cinemachine;
using UnityEngine;
using UnityEngine.InputSystem;

public class ControlledBehaviour : MonoBehaviour
{
    private readonly float gravity = -9.81f;
    private readonly float jumpHeight = 1f;
    private readonly float speed = 2f;

    private Camera _camera;
    private CinemachineBasicMultiChannelPerlin _cameraNoise;
    private CharacterController _character;

    private LayerMask _groundLayer;
    
    private bool _jump;
    private Vector3 _move;
    private float _vy;

    private void Start()
    {
        _character = GetComponent<CharacterController>();
        _groundLayer = LayerMask.GetMask("Ground");

        var virtualCamera = FindObjectOfType<CinemachineVirtualCamera>();
        _cameraNoise = virtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        _camera = Camera.main;
    }

   
    private void Update()
    {
        // walk/run
        var angle = _camera.transform.eulerAngles.y;
        var move = Quaternion.Euler(0f, angle, 0f) * _move * speed;
        
        // Physics.CheckSphere(transform.position + _groundOffset, _groundRadius, _groundLayer);
        var isGrounded = _character.isGrounded;
        if (isGrounded)
        {
            bool hit = Physics.Raycast(transform.position, Vector3.down, out RaycastHit hitInfo, 10f, _groundLayer);
            bool isStable = false;
            Vector3? slide = null;
            if (hit)
            {
                float slope = Mathf.Abs(Vector3.Angle(hitInfo.normal, Vector3.up));
                // Debug.Log(slope);
                isStable = slope < 45f;
                slide = hitInfo.normal;
            }
            else
            {
                Debug.Log("no slope info");
            }

            if (isStable)
            {
                if (_vy < 0) _vy = 0f;
                if (_jump)
                {
                    _jump = false;
                    _vy = Mathf.Sqrt(jumpHeight * -3f * gravity);
                }
            }
            else if (slide.HasValue)
            {
                // slide
                move = slide.Value;
            }
        }

        _vy += gravity * Time.deltaTime;
        move.y = _vy;

        _character.Move(move * Time.deltaTime);
        _cameraNoise.m_AmplitudeGain =
            Mathf.MoveTowards(_cameraNoise.m_AmplitudeGain, _move.magnitude, Time.deltaTime * 5f);
    }

    public void Move(InputAction.CallbackContext context)
    {
        var input = context.ReadValue<Vector2>();
        _move = new Vector3(input.x, 0f, input.y).normalized;
    }

    public void Fire(InputAction.CallbackContext context)
    {
        var dir = Quaternion.Euler(_camera.transform.eulerAngles) * Vector3.forward;
        var hit = Physics.Raycast(transform.position, dir, out var hitInfo);
        if (hit) hitInfo.transform.GetComponent<IInteractable>()?.Interact(this);
    }

    public void Jump(InputAction.CallbackContext context)
    {
        _jump = context.ReadValueAsButton();
    }
}