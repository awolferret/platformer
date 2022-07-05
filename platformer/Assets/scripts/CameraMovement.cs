using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private Transform _player;

    private void FixedUpdate()
    {
        Vector3 cameraPosition = transform.position;
        cameraPosition.x = _player.position.x;
        cameraPosition.y = _player.position.y;
        cameraPosition.z = _player.position.z-1;
        transform.position = cameraPosition;
    }
}