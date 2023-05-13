using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    private const string Fire = "Fire1";

    [SerializeField] private List<Weapon> _weapons;

    private UnityAction _onAttack;

    private Weapon _currentWeapon;
    private float _health = 100.0f;
    private float _currentHealth;

    public float Hit { get; private set; }

    private void Start()
    {
        _currentHealth = _health;
    }

    private void Update()
    {
        Hit = Input.GetAxis(Fire);
    }

    public event UnityAction Attack
    {
        add => _onAttack += value;
        remove => _onAttack -= value;
    }

    private void TryInvokeAttack()
    {

        if (Input.GetMouseButtonDown(0))
            _onAttack?.Invoke();
    }
}
