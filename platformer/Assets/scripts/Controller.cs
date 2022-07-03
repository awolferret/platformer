using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    private PlayerMovement _playerMovement;

    private void Start()
    {
        _playerMovement = GetComponent<PlayerMovement>();
    }

    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.D))
        {
            _playerMovement.MoveRight();
        }

        if (Input.GetKey(KeyCode.A))
        {
            _playerMovement.MoveLeft();
        }

        if (Input.GetKey(KeyCode.Space))
        {
            _playerMovement.Jump();
        }
    }
}