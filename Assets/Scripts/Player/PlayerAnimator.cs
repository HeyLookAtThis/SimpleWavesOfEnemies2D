using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Movement))]
[RequireComponent (typeof(Player))]

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
    }

    private void Update()
    {
        TryingPlayRun();
        TryingPlayAttak();
    }

    public void OnEnable()
    {
    }

    public void OnDisable()
    {
    }

    private void TryingPlayRun()
    {
        if (_movement.Grounded)
            SetSpeedParameter(Mathf.Abs(_movement.Direction));
        else
            SetSpeedParameter();
    }

    private void SetSpeedParameter(float speed = 0)
    {
        _animator.SetFloat(ACPlayer.Params.Speed, speed);
    }

    private void TryingPlayAttak()
    {
        if (_player.Hit != 0)
            _animator.Play(ACPlayer.State.AxeAttack);
    }
}
