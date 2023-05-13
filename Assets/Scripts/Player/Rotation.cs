using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]

public class Rotation : MonoBehaviour
{
    private const string Horizontal = "Horizontal";

    private SpriteRenderer _sprite;

    private void Start()
    {
        _sprite = GetComponent<SpriteRenderer>();
    }

    private void FixedUpdate()
    {
        float direction = Input.GetAxis(Horizontal);

        if (direction < 0)
            _sprite.flipX = true;
        else if(direction > 0)
            _sprite.flipX = false;
    }
}
