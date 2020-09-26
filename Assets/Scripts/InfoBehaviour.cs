using UnityEngine;
using UnityEngine.InputSystem;

public class InfoBehaviour : MonoBehaviour
{
    private CanvasGroup _canvas;
    private bool _shown;

    private void Start()
    {
        _canvas = GetComponent<CanvasGroup>();
    }

    public void Toggle(InputAction.CallbackContext context)
    {
        if (!context.performed) return;
        _shown = !_shown;
        _canvas.alpha = _shown ? 1 : 0;
    }
}