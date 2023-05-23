using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Movement))]
[RequireComponent(typeof(Player))]

public class PlayerAnimator : MonoBehaviour
{
    private Animator _animator;
    private Movement _movement;
    private Player _player;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _movement = GetComponent<Movement>();
        _player = GetComponent<Player>();

        _player.Attacked += PlayAxeAttack;
        _player.TakenDamage += PlayTakeDamage;
        _player.Died += PlayDeath;
    }

    private void Update()
    {
        SetSpeed();
    }

    private void OnDisable()
    {
        _player.Attacked -= PlayAxeAttack;
        _player.TakenDamage -= PlayTakeDamage;
        _player.Died -= PlayDeath;
    }

    private void SetSpeed()
    {
        if (_movement.Grounded)
            _animator.SetFloat(ACPlayer.Params.Speed, Mathf.Abs(_movement.Direction));
        else
            _animator.SetFloat(ACPlayer.Params.Speed, 0);
    }

    private void PlayAxeAttack()
    {
        _animator.SetTrigger(ACPlayer.Params.Attack);
    }

    private void PlayTakeDamage()
    {
        _animator.Play(ACPlayer.State.TakeDamage);
    }

    private void PlayDeath()
    {
        _animator.Play(ACPlayer.State.DeathWithAxe);
    }

    private void PlayAnimation(string animation)
    {
        _animator.Play(animation);
    }
}
