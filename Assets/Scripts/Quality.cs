using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering.PostProcessing;

public class Quality : MonoBehaviour
{
    private float autoSwitchRenderTime = 0.1f;
    private int _switchAfterTimes = 10;
    private int _missed;
    
    private bool _hasSwitched = false;
    private PostProcessLayer _post;
    private InfoBehaviour _info;

    void Start()
    {
        _post = Camera.main.GetComponent<PostProcessLayer>();
        _info = FindObjectOfType<InfoBehaviour>();
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
}
