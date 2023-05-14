using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Axe : Weapon
{
    [SerializeField] private DestructionZone _destruction;

    private DestructionZone _currentDestruction = null;

    public override void Attack(Vector2 position, float rotationY)
    {
        if(_currentDestruction == null)
            InstantiateDestruction(position, rotationY);
    }

    private void InstantiateDestruction(Vector2 position, float rorationY)
    {
        float xAxeOffset;

        if (rorationY == 0)
            xAxeOffset = -0.9f;
        else
            xAxeOffset = 0.9f;

        float yAxeOffset = 0.5f;
        Vector2 correctPosition = new Vector2(position.x + xAxeOffset, position.y + yAxeOffset);

        _currentDestruction = Instantiate(_destruction, correctPosition, Quaternion.identity);
    }
}
