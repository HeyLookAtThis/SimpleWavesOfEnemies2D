using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int _health;

    private void OnTriggerEnter(Collider other)
    {
        if (TryGetComponent<ZoneOfDestructionsFromAxe>(out ZoneOfDestructionsFromAxe destruction))
            TakeDamage(destruction.GetDamage());

        else if (TryGetComponent<Bullet>(out Bullet bullet))
            TakeDamage(bullet.GetDamage());
    }

    private void TakeDamage(int damage)
    {
        _health -= damage;
    }
}
