using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpController : MonoBehaviour
{
    [SerializeField] private float _speed;

    private SpriteRenderer _spriteRenderer;

    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void MoveRight()
    {
        _spriteRenderer.flipX = false;
        transform.Translate(Vector2.right * (_speed * Time.deltaTime));
    }

    public void MoveLeft()
    {
        _spriteRenderer.flipX = true;
        transform.Translate(Vector2.left * (_speed * Time.deltaTime));
    }
}
