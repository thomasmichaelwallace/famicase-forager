using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseControl : MonoBehaviour
{
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void Grab()
    {
        Cursor.lockState = CursorLockMode.Locked;
    } 
}
