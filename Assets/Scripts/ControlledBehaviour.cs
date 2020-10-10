using System;
using Cinemachine;
using Cinemachine.Utility;
using UnityEngine;
using UnityEngine.InputSystem;

public class ControlledBehaviour : MonoBehaviour
{
    private readonly float gravity = -9.81f;
    private readonly float jumpHeight = 1f;
    private readonly float reach = 10f;
    private readonly float speed = 2f;
    private readonly float sprint = 2f;
    private readonly float climb = 50f;

    private Camera _camera;
    private CinemachineBasicMultiChannelPerlin _cameraNoise;
    private CharacterController _character;
    private LayerMask _groundLayer;
    private AudioSource _audio;
    
    private float _walkSlope;
    private bool _jump;
    private Vector3 _move;
    private bool _run;
    private float _vy;

    [NonSerialized] public bool CanJump = true;
    [NonSerialized] public bool CanRun = true;
    [NonSerialized] public bool CanBreak = true;

    private void Start()
    {
        _character = GetComponent<CharacterController>();
        _groundLayer = LayerMask.GetMask("Ground");
        _walkSlope = _character.slopeLimit;

        var virtualCamera = FindObjectOfType<CinemachineVirtualCamera>();
        _cameraNoise = virtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        _camera = Camera.main;

        _audio = GetComponent<AudioSource>();
    }


    private void Update()
    {
        // walk/run
        var angle = _camera.transform.eulerAngles.y;
        var move = Quaternion.Euler(0f, angle, 0f) * _move * speed;
        if (CanRun && _run) move *= sprint;

        var walking = false;
        
        // Physics.CheckSphere(transform.position + _groundOffset, _groundRadius, _groundLayer);
        var isGrounded = _character.isGrounded;
        if (isGrounded)
        {
            var hit = Physics.Raycast(transform.position, Vector3.down, out var hitInfo, 10f, _groundLayer);
            var isStable = false;
            Vector3? slide = null;
            if (hit)
            {
                var slope = Mathf.Abs(Vector3.Angle(hitInfo.normal, Vector3.up));
                // Debug.Log(slope);
                isStable = slope < _character.slopeLimit;
                slide = hitInfo.normal * speed;
            }
            // else
            // {
            //     Debug.Log("no slope info");
            // }

            if (isStable)
            {
                if (_vy < 0) _vy = 0f;
                if (_jump)
                {
                    _jump = false;
                    _vy = Mathf.Sqrt(jumpHeight * -3f * gravity);
                }

                walking = !_move.AlmostZero();
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

        if (walking)
        {
            if (!_audio.isPlaying) _audio.Play();
        }
        else
        {
            if (_audio.isPlaying) _audio.Stop();
        }
    }

    public void Move(InputAction.CallbackContext context)
    {
        var input = context.ReadValue<Vector2>();
        _move = new Vector3(input.x, 0f, input.y).normalized;
    }

    public void Fire(InputAction.CallbackContext context)
    {
        if (!context.performed) return;
        var dir = Quaternion.Euler(_camera.transform.eulerAngles) * Vector3.forward;
        var hit = Physics.Raycast(transform.position, dir, out var hitInfo, reach);
        if (hit) hitInfo.transform.GetComponent<IInteractable>()?.Interact(this);
    }

    public void Jump(InputAction.CallbackContext context)
    {
        if (!CanJump) return;
        _jump = context.ReadValueAsButton();
    }

    public void Run(InputAction.CallbackContext context)
    {
        if (!CanRun) return;
        _run = context.ReadValueAsButton();

        _character.slopeLimit = _run ? climb : _walkSlope;
    }
}