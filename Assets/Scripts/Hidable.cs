using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hidable : MonoBehaviour
{
    private bool _hiding;
    private float _t;
    private InfoBehaviour _info;
    private string _text = "";

    private void Start()
    {
        _info = FindObjectOfType<InfoBehaviour>();
    }

    void Update()
    {
        if (_hiding)
        {
            _t += Time.deltaTime;
            var scale = Vector3.Lerp(Vector3.one, Vector3.zero, _t);
            transform.localScale = scale;

            if (_t >= 1)
            {
                if (_text != "") _info.Show(_text);
                Destroy(gameObject);
            }
        }
    }

    public void Hide(string text)
    {
        _hiding = true;
        _text = text;
    }

    public void Hide()
    {
        _hiding = true;
    }
}
