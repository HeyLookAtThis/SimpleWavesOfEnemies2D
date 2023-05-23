using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Enemy : Character
{
    [SerializeField] private int _reward;

    private Player _target;
    private UnityAction<Enemy> _onDying;

    public Player Target => _target;

    public int Reward => _reward;

    private Weapon _currentWeapon => GetRandomWeapon();

    public event UnityAction<Enemy> Dying
    {
        add => _onDying += value;
        remove => _onDying -= value;
    }

    public void InitializeTarget(Player target)
    {
        _target = target;
    }

    public void Attack()
    {
        _currentWeapon.Attack(transform);
        onAttacked.Invoke();
    }

    private Weapon GetRandomWeapon()
    {
        return _weapons[Random.Range(0, _weapons.Count)];
    }
}
