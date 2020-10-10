using System.Collections;
using System.Collections.Generic;
using System.Xml.Schema;
using UnityEngine;

public class MushCollect : MonoBehaviour, IInteractable
{
    

    private bool _collected = false;

    private Score _score;
    
    void Start()
    {
        _score = FindObjectOfType<Score>();
        _score.Register();
    }

    public void Interact(ControlledBehaviour controlled)
    {
        if (_collected) return;
        
        _collected = true;
        _score.Count();
        
        gameObject.GetComponent<Hidable>().Hide();
    }
}
