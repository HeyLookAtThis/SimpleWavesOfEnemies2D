using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : Character
{
    private Weapon _currentWeapon;

    public int Money { get; private set; }

    public Transform CharacterTransform { get; private set; }

    private void Start()
    {
        _currentWeapon = _weapons[0];
    }

    private void Update()
    {
        CharacterTransform = transform;
        TryAttack();
    }

    public void AddMoney(int money)
    {
        Money += money;
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
            onAttacked.Invoke();
        }
    }
}
