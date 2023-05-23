using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FromMovementToAttackTransition : Transition
{
    [SerializeField] private float _minDistance = 0.6f;
    [SerializeField] private float _maxDistance = 1.1f;

    private float _conditionDistance;

    public float Distance => _conditionDistance;

    private void Start()
    {
        _conditionDistance = Random.Range(_minDistance, _maxDistance);
    }

    private void Update()
    {
        if (Vector2.Distance(transform.position, Target.transform.position) <= _conditionDistance)
            NeedTransit = true;
    }
}
