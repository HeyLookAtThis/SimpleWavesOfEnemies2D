using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [SerializeField] private List<Weapon> _weapons;

    private UnityAction _onAttacked;

    private Weapon _currentWeapon;
    private float _health = 100.0f;
    private float _currentHealth;

    private void Start()
    {
        _currentHealth = _health;
        _currentWeapon = _weapons[0];
    }

    private void Update()
    {
        TryAttack();
    }

    public event UnityAction Attacked
    {
        add => _onAttacked += value;
        remove => _onAttacked -= value;
    }

    private bool GetHit()
    {
        return Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.LeftControl) ? true : false;
    }

    private void TryAttack()
    {
        if (GetHit())
        {
            _currentWeapon.Attack(transform);
            _onAttacked.Invoke();
        }
    }
}
