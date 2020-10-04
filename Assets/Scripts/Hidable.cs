using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hidable : MonoBehaviour
{
    private bool _hiding;
    private float _t;

    void Update()
    {
        if (_hiding)
        {
            _t += Time.deltaTime;
            var scale = Vector3.Lerp(Vector3.one, Vector3.zero, _t);
            transform.localScale = scale;

            if (_t >= 1)
            {
                Destroy(gameObject);
            }
        }
    }

    public void Hide()
    {
        Debug.Log("hiding");
        _hiding = true;
    }
}
