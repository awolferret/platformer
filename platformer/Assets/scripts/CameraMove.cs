using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    private Transform _player;

    void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void FixedUpdate()
    {
        Vector3 cameraPosition = transform.position;
        cameraPosition.x = _player.position.x;
        cameraPosition.y = _player.position.y;
        cameraPosition.z = _player.position.z-1;
        transform.position = cameraPosition;
    }
}