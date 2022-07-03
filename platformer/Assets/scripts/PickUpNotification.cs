using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PickUpNotification : MonoBehaviour
{
    [SerializeField] private UnityEvent _pickUp;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Coin>(out Coin coin))
        {
            _pickUp.Invoke();
        }
    }
}