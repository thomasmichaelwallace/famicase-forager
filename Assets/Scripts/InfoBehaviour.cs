using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class InfoBehaviour : MonoBehaviour
{
    private ControlledBehaviour _player;
    private CanvasGroup _canvas;
    public CanvasGroup titleCanvas;
    private TextMeshProUGUI _text;
    private bool _shown;
    private bool _title = true;

    private void Start()
    {
        _canvas = GetComponent<CanvasGroup>();
        _text = GetComponentInChildren<TextMeshProUGUI>();
        _player = FindObjectOfType<ControlledBehaviour>();
    }

    
    
    private void SetText()
    {
        string text = "Forage for mushrooms<size=20%>\n\n</size><size=80%>{mouse} to look\n{click} to pickup";
        if (_player.CanBreak) text += "/smash";
        text += "\n{wasd} to move";
        if (_player.CanJump) text += "\n{space} to jump";
        if (_player.CanRun) text += "\nhold {shift} to run";
        text += "\n{1} to switch quality";
        text += "\n{+/-} in/de-crease look speed</size>";

        text += "<size=75%>\n\n{click} to continue</size>";
        _text.text = text;
    }
    
    public void Toggle(InputAction.CallbackContext context)
    {
        if (!context.performed) return;
        
        if (_title)
        {
            titleCanvas.alpha = 0;
            _title = false;
            return;
        }
        
        _shown = !_shown;
        if (_shown) SetText();
        _canvas.alpha = _shown ? 1 : 0;
    }

    public void Show(string text)
    {
        _shown = true;
        _canvas.alpha = _shown ? 1 : 0;
        _text.text = text + "<size=75%>\n\n{click} to continue</size>";
    }

    public void Hide()
    {
        if (_title)
        {
            titleCanvas.alpha = 0;
            _title = false;
        }
        else
        {
            _shown = false;
            _canvas.alpha = 0;   
        }
    }
}