using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BanditAnimator))]

public class BanditCelebration : State
{
    private BanditAnimator _banditAnimator;

    private void Start()
    {
        _banditAnimator = GetComponent<BanditAnimator>();
        _banditAnimator.PlayCelebrate();
    }
}
