using System;
using UnityEngine;

public class MushWin : MonoBehaviour, IInteractable
{
    public GameObject win;
    
    public void Interact(ControlledBehaviour controlled)
    {
        win.SetActive(true);
        gameObject.GetComponent<Hidable>().Hide("You found a\n<size=130%>HOMESHROOM!</size>\nJust make sure you're\nfinished before you find\nthe other...");
    }
}