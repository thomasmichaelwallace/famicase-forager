using UnityEngine;

public class InteractableBehaviour : MonoBehaviour, IInteractable
{
    public Material selected;

    private Material _material;
    private Renderer _renderer;
    private bool _toggled;

    private void Start()
    {
        _renderer = GetComponent<Renderer>();
        _material = _renderer.material;
    }

    public void Interact(ControlledBehaviour controlled)
    {
        _toggled = !_toggled;
        _renderer.material = _toggled ? selected : _material;
    }
}