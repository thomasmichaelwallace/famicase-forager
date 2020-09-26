using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlledBehaviour : MonoBehaviour
{
    private CharacterController _characterController;
    
    void Start()
    {
        _characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        Vector3 input = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical")).normalized;
        float angle = Camera.main.transform.eulerAngles.y;
        Vector3 move = Quaternion.Euler(0f, angle, 0f) * input;
        
        _characterController.SimpleMove( move);
    }
}
