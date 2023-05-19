using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UIElements;

public class Axe : Weapon
{
    [SerializeField] private DestructionZone _destruction;

    private DestructionZone _currentDestruction = null;

    public override void Attack(Transform transform)
    {
        if(_currentDestruction == null)
            InstantiateDestruction(transform);

        _currentDestruction.Run();
    }

    private void InstantiateDestruction(Transform transform)
    {
        _currentDestruction = Instantiate(_destruction, GetStartingPosition(transform.position), Quaternion.identity, transform);
    }

    private Vector2 GetStartingPosition(Vector2 position)
    {
        float yPosition = 1.6f;

        return new Vector2(position.x, position.y + yPosition);
    }
}
