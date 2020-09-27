using UnityEngine;

public class MushRun : MonoBehaviour, IInteractable
{
    public void Interact(ControlledBehaviour controlled)
    {
        controlled.CanRun = true;
        Destroy(gameObject);
    }
}