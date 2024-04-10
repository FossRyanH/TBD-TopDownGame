using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class RoofHide : MonoBehaviour
{
    TilemapRenderer _roof;
    bool _isHidden = false;

    void Awake()
    {
        _roof = GetComponent<TilemapRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<PlayerController>())
        {
            _isHidden = true;
            _roof.enabled = !_isHidden;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<PlayerController>())
        {
            _isHidden = false;
            _roof.enabled = !_isHidden;
        }
    }
}
