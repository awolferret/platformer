using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Saw : MonoBehaviour
{
    [SerializeField] private float _force;

    private SpriteRenderer _spriteRenderer;

    private void Start()
    {
        transform.DOMove(new Vector2(-9.62f, -3.41f), 3).SetEase(Ease.Linear).SetLoops(-1, LoopType.Yoyo);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Rigidbody2D>(out Rigidbody2D rigidbody2D))
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();

            if (_spriteRenderer.flipX == true)
            {
                rigidbody2D.velocity = (Vector2.left * _force * Time.deltaTime);
            }
            else
            {
                rigidbody2D.velocity = (Vector2.right * _force * Time.deltaTime);
            }
        }
    }
}