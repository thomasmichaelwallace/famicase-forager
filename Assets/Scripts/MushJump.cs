﻿using UnityEngine;

public class MushJump : MonoBehaviour, IInteractable
{
    public void Interact(ControlledBehaviour controlled)
    {
        controlled.CanJump = true;
        Destroy(gameObject);
    }
}