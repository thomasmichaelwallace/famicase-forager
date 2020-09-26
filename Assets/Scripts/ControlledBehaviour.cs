using Cinemachine;
using UnityEngine;
using UnityEngine.InputSystem;

public class ControlledBehaviour : MonoBehaviour
{
    private Camera _camera;
    private CinemachineBasicMultiChannelPerlin _cameraNoise;
    private CharacterController _characterController;

    private Vector3 _move;
    
    private void Start()
    {
        _characterController = GetComponent<CharacterController>();
        var virtualCamera = FindObjectOfType<CinemachineVirtualCamera>();
        _cameraNoise = virtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        _camera = Camera.main;
    }

    private void Update()
    {
        var angle = _camera.transform.eulerAngles.y;
        var move = Quaternion.Euler(0f, angle, 0f) * _move;
        _characterController.SimpleMove(move);

        _cameraNoise.m_AmplitudeGain =
            Mathf.MoveTowards(_cameraNoise.m_AmplitudeGain, _move.magnitude, Time.deltaTime * 5f);
    }

    public void Move(InputAction.CallbackContext context)
    {
        var input = context.ReadValue<Vector2>();
        Debug.Log(input);
        _move = new Vector3(input.x, 0f, input.y).normalized;
    }

    public void Fire(InputAction.CallbackContext context)
    {
        Vector3 dir = Quaternion.Euler(_camera.transform.eulerAngles) * Vector3.forward;
        var hit = Physics.Raycast(transform.position, dir, out var hitInfo);
        if (hit)
        {
            var interactableBehaviour = hitInfo.transform.GetComponent<InteractableBehaviour>();
            if (interactableBehaviour) interactableBehaviour.Toggle();
        }
    }
    
}