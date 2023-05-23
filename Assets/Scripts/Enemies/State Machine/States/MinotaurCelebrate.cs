using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MinotaurAnimator))]

public class MinotaurCelebrate : State
{
    private MinotaurAnimator _minotaurAnimator;

    private void Start()
    {
        _minotaurAnimator = GetComponent<MinotaurAnimator>();
        _minotaurAnimator.PlayCelebrate();
    }
}
