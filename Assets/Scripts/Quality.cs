using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering.PostProcessing;

public class Quality : MonoBehaviour
{
    private float autoSwitchRenderTime = 500f;
    private PostProcessLayer _post;

    void Start()
    {
        _post = Camera.main.GetComponent<PostProcessLayer>();
    }
    
    void Update()
    {
        if (Time.deltaTime > autoSwitchRenderTime)
        {
            _post.enabled = false;
        }
    }
    
    public void Toggle(InputAction.CallbackContext context)
    {
        if (context.performed) _post.enabled = !_post.enabled;
    }
}
