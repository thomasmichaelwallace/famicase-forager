using Cinemachine;
using UnityEngine;

public class ControlledBehaviour : MonoBehaviour
{
    private CinemachineBasicMultiChannelPerlin _cameraNoise;
    private CharacterController _characterController;

    private void Start()
    {
        _characterController = GetComponent<CharacterController>();
        var camera = FindObjectOfType<CinemachineVirtualCamera>();
        _cameraNoise = camera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
    }

    private void Update()
    {
        var input = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical")).normalized;
        var angle = Camera.main.transform.eulerAngles.y;
        var move = Quaternion.Euler(0f, angle, 0f) * input;

        _cameraNoise.m_AmplitudeGain = Mathf.MoveTowards(_cameraNoise.m_AmplitudeGain, move.magnitude, Time.deltaTime * 5f);

        _characterController.SimpleMove(move);
    }
}