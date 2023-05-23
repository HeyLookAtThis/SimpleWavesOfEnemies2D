using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

[RequireComponent(typeof(FromMovementToAttackTransition))]

public class FromAttackToMovementTransition : Transition
{
    private FromMovementToAttackTransition _transition;

    private void Awake()
    {
        _transition = GetComponent<FromMovementToAttackTransition>();
    }

    private void Update()
    {
        if (Vector2.Distance(transform.position, Target.transform.position) > _transition.Distance)
            NeedTransit = true;
    }
}
