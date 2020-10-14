using TMPro;
using UnityEngine;

public class MushFinal : MonoBehaviour, IInteractable
{
    public CanvasGroup screen;

    private bool _collected;

    private TextMeshProUGUI _text;
    private Score _score;

    private void Start()
    {
        _text = screen.GetComponentInChildren<TextMeshProUGUI>();
        _score = FindObjectOfType<Score>();
    }

    private void Update()
    {
        if (!_collected) return;
        if (screen.alpha < 1) screen.alpha += Time.deltaTime;
    }

    public void Interact(ControlledBehaviour controlled)
    {
        _collected = true;
        _text.text = "FORAGER\n<size=30>You foraged " + _score.GetText() + " of the hidden mushrooms!</size>";
        gameObject.GetComponent<Hidable>().Hide();
    }
}