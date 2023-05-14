using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    private const string Fire = "Fire1";

    [SerializeField] private List<Weapon> _weapons;

    private UnityAction _onAttacked;

    private Weapon _currentWeapon;
    private float _health = 100.0f;
    private float _currentHealth;

    public float Hit { get; private set; }

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

    private void TryAttack()
    {
        Hit = Input.GetAxis(Fire);

        if (Hit != 0)
        {
            _currentWeapon.Attack();
            _onAttacked.Invoke();
        }
    }
}
