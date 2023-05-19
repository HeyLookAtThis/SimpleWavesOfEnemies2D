using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
[RequireComponent(typeof(Animator))]

public class BanditAnimator : MonoBehaviour
{
    private Enemy _enemy;
    private Animator _animator;

    private void Awake()
    {
        _enemy.TakenDamage += PlayTakingDamage;
        _enemy.Died += PlayDying;
    }

    private void Start()
    {
        _enemy = GetComponent<Enemy>();
        _animator = GetComponent<Animator>();
    }

    //private void OnDestroy()
    //{
    //    _enemy.TakenDamage -= PlayTakingDamage;
    //    _enemy.Died -= PlayDying;
    //}

    private void PlayTakingDamage()
    {
        _animator.Play(ACBandit.State.BanditTakeDamage);
    }

    private void PlayDying()
    {
        _animator.Play(ACBandit.State.BanditDie);
    }
}
