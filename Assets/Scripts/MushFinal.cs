using TMPro;
using UnityEngine;

public class MushFinal : MonoBehaviour, IInteractable
{
    public CanvasGroup screen;

    private bool _collected;

    private TextMeshProUGUI _text;

    private void Start()
    {
        _text = screen.GetComponentInChildren<TextMeshProUGUI>();
    }

    private void Update()
    {
        if (!_collected) return;
        if (screen.alpha < 1) screen.alpha += Time.deltaTime;
    }

    public void Interact(ControlledBehaviour controlled)
    {
        _collected = true;
        _text.text = "You Win!";
    }
}