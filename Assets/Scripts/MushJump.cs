using System;
using UnityEngine;

public class MushJump : MonoBehaviour, IInteractable
{
    public void Interact(ControlledBehaviour controlled)
    {
        controlled.CanJump = true;
        gameObject.GetComponent<Hidable>().Hide("You found a\nJumpShroom!\nPress [Space] to jump!");
    }
}