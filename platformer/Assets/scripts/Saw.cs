using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Saw : MonoBehaviour
{
    [SerializeField] private float _force;
    [SerializeField] private SpriteRenderer _spriteRenderer;

    private Vector2 direction;

    private void Start()
    {
        transform.DOMove(new Vector2(-9.62f, -3.41f), 3).SetEase(Ease.Linear).SetLoops(-1, LoopType.Yoyo);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Rigidbody2D>(out Rigidbody2D rigidbody2D))
        {
            if (_spriteRenderer.flipX == true)
            {
                direction = Vector2.left;
                Push(direction,rigidbody2D);
            }
            else if(_spriteRenderer.flipX == false)
            {
                direction = Vector2.right;
                Push(direction, rigidbody2D);
            }
        }
    }

    private void Push(Vector2 direction,Rigidbody2D rigidbody2D)
    {
        rigidbody2D.velocity = (direction * _force * Time.deltaTime);
    }
}