using System;
using UnityEngine;

public class MushJump : MonoBehaviour, IInteractable
{
    public void Interact(ControlledBehaviour controlled)
    {
        controlled.CanJump = true;
        gameObject.GetComponent<Hidable>().Hide("You found a\n<size=130%>JUMPSHROOM!</size>\nPress {space} to jump");
    }
}