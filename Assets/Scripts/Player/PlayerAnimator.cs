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

        _player.Attacked += SetAxeAttack;
    }

    private void Update()
    {
        SetSpeed();
    }

    private void OnDisable()
    {
        _player.Attacked -= SetAxeAttack;
    }

    private void SetSpeed()
    {
        if (_movement.Grounded)
            _animator.SetFloat(ACPlayer.Params.Speed, Mathf.Abs(_movement.Direction));
        else
            _animator.SetFloat(ACPlayer.Params.Speed, 0);
    }

    private void SetAxeAttack()
    {
        _animator.Play(ACPlayer.State.AxeAttack);
    }
}
