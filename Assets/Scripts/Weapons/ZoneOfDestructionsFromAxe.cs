using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CapsuleCollider2D))]

public class ZoneOfDestructionsFromAxe : MonoBehaviour
{
    [SerializeField] private int _damage;

    private CapsuleCollider2D _collider;

    private void Start()
    {
        _collider = GetComponent<CapsuleCollider2D>();
        _collider.isTrigger = true;

        SetSizeCollider();
    }

    public int GetDamage()
    {
        return _damage;
    }

    private void SetSizeCollider()
    {
        float xSize = 0.3f;
        float ySize = 1.1f;

        _collider.size.Set(xSize, ySize);
    }
}
