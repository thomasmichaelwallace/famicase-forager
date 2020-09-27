using UnityEngine;

public class Boulder : MonoBehaviour, IInteractable
{
    public void Interact(ControlledBehaviour controlled)
    {
        if (controlled.CanBreak) Destroy(gameObject);
    }
}