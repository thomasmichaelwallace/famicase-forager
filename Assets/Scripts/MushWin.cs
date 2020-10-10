using System;
using UnityEngine;

public class MushWin : MonoBehaviour, IInteractable
{
    public GameObject win;
    
    public void Interact(ControlledBehaviour controlled)
    {
        win.SetActive(true);
        gameObject.GetComponent<Hidable>().Hide("You've found the winshroom!\nFind it again to go home.\nJust make sure you're ready before your pick it!");
    }
}