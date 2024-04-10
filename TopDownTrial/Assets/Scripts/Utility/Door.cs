using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    Animator _animator;
    BoxCollider2D _boxCollider;

    void Awake()
    {
        _animator = GetComponent<Animator>();
        _boxCollider = GetComponent<BoxCollider2D>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<PlayerController>())
        {
            _animator.Play("DoorOpen");
            _boxCollider.enabled = false;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.GetComponent<PlayerController>())
        {
            _animator.Play("ClosingDoor");
            _boxCollider.enabled = true;
        }  
    }
}
