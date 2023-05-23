using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UIElements;

public class Axe : Weapon
{
    [SerializeField] private PlayerAxBlow _attack;

    private PlayerAxBlow _currentDestruction = null;

    public override void Attack(Transform transform)
    {
        if (_currentDestruction == null)
            _currentDestruction = Instantiate(_attack, GetStartingPosition(transform.position), Quaternion.identity, transform);

        _currentDestruction.Run();
    }

    private Vector2 GetStartingPosition(Vector2 position)
    {
        float yPosition = 1.6f;

        return new Vector2(position.x, position.y + yPosition);
    }
}
