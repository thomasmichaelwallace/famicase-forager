using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class InfoBehaviour : MonoBehaviour
{
    private ControlledBehaviour _player;
    private CanvasGroup _canvas;
    private TextMeshProUGUI _text;
    private bool _shown;

    private void Start()
    {
        _canvas = GetComponent<CanvasGroup>();
        _text = GetComponentInChildren<TextMeshProUGUI>();
        _player = FindObjectOfType<ControlledBehaviour>();
    }

    private void SetText()
    {
        string text = "Forage for mushrooms to get more abilities.";
        if (_player.CanJump) text += "\nYou have the jump ability!";
        if (_player.CanRun) text += "\nYou have the run ability!";
        if (_player.CanBreak) text += "\nYou have the break ability!";
        _text.text = text;
    }
    
    public void Toggle(InputAction.CallbackContext context)
    {
        if (!context.performed) return;
        _shown = !_shown;
        if (_shown) SetText();
        _canvas.alpha = _shown ? 1 : 0;
    }

    public void Show(string text)
    {
        _shown = true;
        _canvas.alpha = _shown ? 1 : 0;
        _text.text = text + "\n\n([Click] to hide)";
    }

    public void Hide()
    {
        _shown = false;
        _canvas.alpha = 0;
    }
}