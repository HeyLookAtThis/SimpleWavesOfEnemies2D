using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Axe : Weapon
{
    [SerializeField] private Player _player;

    [SerializeField] private ZoneOfDestructionsFromAxe _destructions;

    public override void Attack()
    {
        InstantiateDestruction();
    }

    private void InstantiateDestruction()
    {
        float xAxeOffset = -0.9f;
        float yAxeOffset = 0.5f;

        Vector2 position = new Vector2(xAxeOffset + _player.transform.position.x, yAxeOffset + _player.transform.position.x);

        Instantiate(_destructions, position, Quaternion.identity);
    }
}
