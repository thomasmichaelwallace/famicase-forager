using UnityEngine;

public class MushBreak : MonoBehaviour, IInteractable
{
    public void Interact(ControlledBehaviour controlled)
    {
        controlled.CanBreak = true;
        Destroy(gameObject);
    }
}