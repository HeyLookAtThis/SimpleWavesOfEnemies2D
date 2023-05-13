using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody2D))]

public class Movement : MonoBehaviour
{
    private const string Horizontal = "Horizontal";
    private const string Vertical = "Vertical";

    [SerializeField] private float _speed = 3;
    [SerializeField] private float _jumpForce = 5;
    [SerializeField] private LayerMask _layerMask;

    private Rigidbody2D _rigidbody;
    private float _circleRadius = 0.05f;

    public bool Grounded { get; private set; }

    public float Direction { get; private set; }

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Move();
    }

    private void FixedUpdate()
    {
        Grounded = Physics2D.OverlapCircle(transform.position, _circleRadius, _layerMask);

        TakeJump();
    }

    private void TakeJump()
    {
        if (Grounded && Input.GetAxis(Vertical) > 0)
            _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, _jumpForce);
    }

    private void Move()
    {
        Direction = Input.GetAxis(Horizontal);
        _rigidbody.velocity = new Vector2(Direction * _speed, _rigidbody.velocity.y);
    }
}
