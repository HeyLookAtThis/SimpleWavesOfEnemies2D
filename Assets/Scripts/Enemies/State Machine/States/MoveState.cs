using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]

public class MoveState : State
{
    [SerializeField] private float _speed;

    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        _animator.SetFloat(ACBandit.Params.Speed, _speed);
    }

    private void Update()
    {
        //transform.Translate(Target.CharacterTransform.position * _speed * Time.deltaTime);
        transform.position = Vector2.MoveTowards(transform.position, Target.CharacterTransform.position, _speed * Time.deltaTime);
        //Debug.Log($"Target.transform.position = {Target.transform.position}");
        //Debug.Log($"_speed * Time.deltaTime = {_speed * Time.deltaTime}");
        //Debug.Log($"Vector2.MoveTowards(transform.position, Target.CharacterTransform.position, _speed * Time.deltaTime) = {Vector2.MoveTowards(transform.position, Target.CharacterTransform.position, _speed * Time.deltaTime)}");

    }

    private void OnDisable()
    {
        _animator.SetFloat(ACBandit.Params.Speed, 0);
    }
}
