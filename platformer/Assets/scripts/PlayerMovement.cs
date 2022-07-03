using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;

    private Rigidbody2D _rigidbody;
    private SpriteRenderer _spriteRenderer;
    private Animator _animator;
    private JumpController _jumpController;
    private float _walkTime;
    private float _walkTImeCooldown = 0.1f;
    private MoveState _moveState = MoveState.Idle;
    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _animator = GetComponent<Animator>();
        _jumpController = GetComponent<JumpController>();
    }
    public void MoveRight()
    {
        if (_moveState != MoveState.Jump)
        {
            _moveState = MoveState.Walk;
            _spriteRenderer.flipX = false;
            _animator.Play("run");
            transform.Translate(Vector2.right * (_speed * Time.deltaTime));
            _walkTime = _walkTImeCooldown;
        }
    }

    public void MoveLeft()
    {
        if (_moveState != MoveState.Jump)
        {
            _moveState = MoveState.Walk;
            _spriteRenderer.flipX = true;
            _animator.Play("run");
            transform.Translate(Vector2.left * (_speed * Time.deltaTime));
            _walkTime = _walkTImeCooldown;
        }
    }

    public void Jump()
    {
        if (_moveState != MoveState.Jump)
        {
            _animator.Play("jump");
            _moveState = MoveState.Jump;
            _rigidbody.velocity = (Vector2.up * _jumpForce * Time.deltaTime);
        }
    }

    public void Idle()
    {
        _moveState = MoveState.Idle;
        _animator.Play("idle");
    }

    private void FixedUpdate()
    {
        if (_moveState == MoveState.Jump)
        {
            if (Input.GetKey(KeyCode.D))
            {
                _jumpController.MoveRight();
            }

            if (Input.GetKey(KeyCode.A))
            {
                _jumpController.MoveLeft();
            }

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