using UnityEngine;

public class MushBreak : MonoBehaviour, IInteractable
{
    public void Interact(ControlledBehaviour controlled)
    {
        controlled.CanBreak = true;
        gameObject.GetComponent<Hidable>().Hide("You found a\n<size=130%>SMASHSHROOM!</size>\n{click} to smash\nboulders!");
    }
}