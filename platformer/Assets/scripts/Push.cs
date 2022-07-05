using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Push : MonoBehaviour
{
    [SerializeField] private float _force;
    [SerializeField] private SpriteRenderer _spriteRenderer;

    private Vector2 _direction;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Rigidbody2D>(out Rigidbody2D rigidbody2D))
        {
            if (_spriteRenderer.flipX == true)
            {
                _direction = Vector2.right;
                Poke(_direction, rigidbody2D);
            }
            else if (_spriteRenderer.flipX == false)
            {
                _direction = Vector2.left;
                Poke(_direction, rigidbody2D);
            }
        }
    }

    private void Poke(Vector2 direction, Rigidbody2D rigidbody2D)
    {
        rigidbody2D.velocity = (direction * _force * Time.deltaTime);
    }
}