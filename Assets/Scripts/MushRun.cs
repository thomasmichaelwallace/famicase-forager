using UnityEngine;

public class MushRun : MonoBehaviour, IInteractable
{
    public void Interact(ControlledBehaviour controlled)
    {
        controlled.CanRun = true;
        gameObject.GetComponent<Hidable>().Hide("You found a\n<size=130%>SPEEDSHROOM!</size>\nHold {shift} to run\nand climb");
    }
}