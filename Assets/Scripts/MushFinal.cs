using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MushFinal : MonoBehaviour, IInteractable
{
    public CanvasGroup screen;

    private TextMeshProUGUI _text;
    
    private bool _collected;

    private void Start()
    {
        _text = screen.GetComponentInChildren<TextMeshProUGUI>();
    }

    private void Update()
    {
        if (!_collected) return;
        if (screen.alpha < 1)
        {
            screen.alpha += Time.deltaTime;
        }
    }

    public void Interact(ControlledBehaviour controlled)
    {
        _collected = true;
        _text.text = "You Win!";
    }
}
