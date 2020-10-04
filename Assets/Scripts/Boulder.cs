using System;
using UnityEngine;

public class Boulder : MonoBehaviour, IInteractable
{
    private Explodable _explodable;
    private bool _exploded;

    private void Start()
    {
        _explodable = GetComponent<Explodable>();
    }

    public void Interact(ControlledBehaviour controlled)
    {
        if (controlled.CanBreak && !_exploded)
        {
            _exploded = true;
            _explodable.Explode(transform.GetChild((0)));
            Destroy(gameObject, 0.5f);
        }
    }
}