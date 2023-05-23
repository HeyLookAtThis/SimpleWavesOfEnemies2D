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
        _enemy = GetComponent<Enemy>();
        _animator = GetComponent<Animator>();
    }

    private void Start()
    {
        _enemy.Attacked += PlayAttack;
        _enemy.TakenDamage += PlayTakingDamage;
        _enemy.Died += PlayDying;
    }

    private void OnDestroy()
    {
        _enemy.Attacked -= PlayAttack;
        _enemy.TakenDamage -= PlayTakingDamage;
        _enemy.Died -= PlayDying;
    }

    public void SetSpeed(float speed)
    {
        _animator.SetFloat(ACBandit.Params.Speed, speed);
    }

    public void PlayCelebrate()
    {
        _animator.Play(ACBandit.State.BanditCelebrations);
    }

    private void PlayTakingDamage()
    {
        _animator.Play(ACBandit.State.BanditTakeDamage);
    }

    private void PlayDying()
    {
        _animator.Play(ACBandit.State.BanditDie);
    }

    private void PlayAttack()
    {
        _animator.SetTrigger(ACBandit.Params.Attack);
    }
}
