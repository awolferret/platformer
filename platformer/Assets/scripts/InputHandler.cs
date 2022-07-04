using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
    private PlayerMovement _playerMovement;
    private Vector2 _rightDirection = Vector2.right;
    private Vector2 _leftDirection = Vector2.left;
    private bool _flipX;

    private void Start()
    {
        _playerMovement = GetComponent<PlayerMovement>();
    }

    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.D))
        {
            _flipX = false;
            _playerMovement.Move(_rightDirection,_flipX);
        }

        if (Input.GetKey(KeyCode.A))
        {
            _flipX = true;
            _playerMovement.Move(_leftDirection,_flipX);
        }

        if (Input.GetKey(KeyCode.Space))
        {
            _playerMovement.Jump();
        }
    }
}