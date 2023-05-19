using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class PlayerRotation : MonoBehaviour
{
    private const string Horizontal = "Horizontal";

    private float _leftAngle = 0f;
    private float _rightAngle = 180f;

    private Quaternion _currentRotation;

    private void Start()
    {
        _currentRotation = transform.rotation;
    }

    private void FixedUpdate()
    {
        float direction = Input.GetAxis(Horizontal);

        if (direction < 0)
            SetRotation(_leftAngle);
        else if (direction > 0)
            SetRotation(_rightAngle);
    }

    private void SetRotation(float angle)
    {
        _currentRotation.y = angle;
        transform.rotation = _currentRotation;
    }    
}
