using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering.PostProcessing;

public class Quality : MonoBehaviour
{
    public CinemachineVirtualCamera virtualCamera;
    
    private float autoSwitchRenderTime = 0.1f;
    private int _switchAfterTimes = 10;
    private int _missed;
    
    private bool _hasSwitched = false;
    private PostProcessLayer _post;
    private InfoBehaviour _info;
    private CinemachinePOV _pov;

    void Start()
    {
        _post = Camera.main.GetComponent<PostProcessLayer>();
        _info = FindObjectOfType<InfoBehaviour>();
        _pov = virtualCamera.GetCinemachineComponent<CinemachinePOV>();
    }
    
    void Update()
    {
        if (_hasSwitched) return;
        if (Time.deltaTime > autoSwitchRenderTime)
        {
            _missed += 1;
        }
        if (_missed > _switchAfterTimes)
        {
            _hasSwitched = true;
            _post.enabled = false;
            _info.Show("Quality auto-switched.\nPress {1} to switch back");
        }
    }
    
    public void Toggle(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            _hasSwitched = true;
            _post.enabled = !_post.enabled;
        }
    }

    public void Sensitivity(InputAction.CallbackContext context)
    {
        if (!context.performed) return;
        float delta = context.ReadValue<float>() * 10;
        float speed = _pov.m_HorizontalAxis.m_MaxSpeed;
        speed = Mathf.Clamp(speed += delta, 10, 360);
        _pov.m_HorizontalAxis.m_MaxSpeed = speed;
    }
}
