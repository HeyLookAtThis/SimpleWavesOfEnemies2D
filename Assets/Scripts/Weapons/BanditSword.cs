using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BanditSword : Weapon
{
    [SerializeField] private BanditSwordAttack _attack;

    private BanditSwordAttack _currentAttack = null;

    public override void Attack(Transform transform)
    {
        if (_currentAttack == null)
            _currentAttack = Instantiate(_attack, GetPosition(), Quaternion.identity, transform); ;

        _currentAttack.Run();
    }

    private Vector2 GetPosition()
    {
        float XPosition = 0.6f;
        float YPosition = 1;

        return new Vector2(XPosition, YPosition);
    }
}
