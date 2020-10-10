using System.Collections;
using System.Collections.Generic;
using System.Xml.Schema;
using UnityEngine;

public class MushCollect : MonoBehaviour, IInteractable
{
    private static int _total = 0;
    private static int _found = 0;

    private bool _collected = false;
    
    void Start()
    {
        _total += 1;
    }

    public void Interact(ControlledBehaviour controlled)
    {
        if (_collected) return;
        
        _collected = true;
        _found += 1;
        
        Debug.Log("found " + _found + " of " + _total);
        
        gameObject.GetComponent<Hidable>().Hide();
    }
}
