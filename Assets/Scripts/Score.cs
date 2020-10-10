using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    private int _total = 0;
    private int _found = 0;

    private TextMeshProUGUI _text;
    
    void Start()
    {
        _text = GetComponent<TextMeshProUGUI>();
    }

    public void Register()
    {
        _total += 1;
        SetText();
    }

    public void Count()
    {
        _found += 1;
        SetText();
    }

    void SetText()
    {
        _text.text = "{" + _found + "/" + _total + "}";
    }
}
