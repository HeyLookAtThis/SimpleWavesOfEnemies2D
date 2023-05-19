using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
[RequireComponent (typeof(Animator))]

public class MinotaurAnimator : MonoBehaviour
{
    private Enemy _enemy;
    private Animator _animator;

    private void Start()
    {
        _enemy = GetComponent<Enemy>();
        _animator = GetComponent<Animator>();

        _enemy.TakenDamage += PlayTakingDamage;
        _enemy.Died += PlayDying;
    }

    private void OnDestroy()
    {
        _enemy.TakenDamage -= PlayTakingDamage;
        _enemy.Died -= PlayDying;
    }

    private void PlayTakingDamage()
    {
        _animator.Play(ACMinotaur.State.MinotaurTakeDamage);
    }

    private void PlayDying()
    {
        _animator.Play(ACMinotaur.State.MinotaurDied);
    }
}
