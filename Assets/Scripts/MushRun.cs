using UnityEngine;

public class MushRun : MonoBehaviour, IInteractable
{
    public void Interact(ControlledBehaviour controlled)
    {
        controlled.CanRun = true;
        gameObject.GetComponent<Hidable>().Hide("You found a\nSpeedShroom!\nHold [Shift] to jump!");
    }
}