using Cinemachine;
using UnityEngine;

public class ControlledBehaviour : MonoBehaviour
{
    private Camera _camera;
    private CinemachineBasicMultiChannelPerlin _cameraNoise;
    private CharacterController _characterController;

    private void Start()
    {
        _characterController = GetComponent<CharacterController>();
        var virtualCamera = FindObjectOfType<CinemachineVirtualCamera>();
        _cameraNoise = virtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        _camera = Camera.main;
    }

    private void Update()
    {
        var input = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical")).normalized;

        var angle = _camera.transform.eulerAngles.y;
        var move = Quaternion.Euler(0f, angle, 0f) * input;
        _characterController.SimpleMove(move);

        _cameraNoise.m_AmplitudeGain =
            Mathf.MoveTowards(_cameraNoise.m_AmplitudeGain, input.magnitude, Time.deltaTime * 5f);

        var fire = Input.GetButton("Fire1");
        if (fire)
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
}