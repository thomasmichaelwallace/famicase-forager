using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MouseControl : MonoBehaviour
{
    private InfoBehaviour _info;
    
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        _info = FindObjectOfType<InfoBehaviour>();
    }

    public void Grab(InputAction.CallbackContext context)
    {
        if (!context.performed) return;
        Cursor.lockState = CursorLockMode.None;
        Cursor.lockState = CursorLockMode.Locked;
        if (Cursor.lockState != CursorLockMode.Locked || Cursor.visible)
        {
            _info.Show("Could not capture mouse. Try switching back/forth tabs");
        }
    } 
}
