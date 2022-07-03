using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Animator))]

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;

    private Rigidbody2D _rigidbody;
    private SpriteRenderer _spriteRenderer;
    private Animator _animator;
    private float _walkTime;
    private float _walkTImeCooldown = 0.1f;
    private float _inJumpSpeed = 2f;
    private MoveState _moveState = MoveState.Idle;

    public void Move(Vector2 direction, bool flipX)
    {
        if (_moveState != MoveState.Jump)
        {
            _moveState = MoveState.Walk;
            _spriteRenderer.flipX = flipX;
            _animator.Play(States.Run);
            transform.Translate(direction * (_speed * Time.deltaTime));
            _walkTime = _walkTImeCooldown;
        }
        else
        {
            _spriteRenderer.flipX = flipX;
            transform.Translate(direction * ((_speed - _inJumpSpeed) * Time.deltaTime));
        }
    }

    public void Jump()
    {
        if (_moveState != MoveState.Jump)
        {
            _animator.Play(States.Jump);
            _moveState = MoveState.Jump;
            _rigidbody.velocity = (Vector2.up * _jumpForce * Time.deltaTime);
        }
    }

    public void Idle()
    {
        _moveState = MoveState.Idle;
        _animator.Play(States.Idle);
    }

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _animator = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        if (_moveState == MoveState.Jump)
        {
            if (_rigidbody.velocity == Vector2.zero)
            {
                Idle();
            }
        }

        else if (_moveState == MoveState.Walk)
        {
            _walkTime -= Time.deltaTime;

            if (_walkTime <= 0)
            {
                Idle();
            }
        }
    }

    private enum MoveState
    { 
        Idle,
        Walk,
        Jump
    }
}

    class States 
    {
        public const string Idle = "idle"; 
        public const string Run = "run";
        public const string Jump = "jump";
    }