using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CapsuleCollider2D))]

public class DestructionZone : MonoBehaviour
{
    [SerializeField] private int _damage;

    private CapsuleCollider2D _collider;
    private Coroutine _liveCounter;

    private void Start()
    {
        _collider = GetComponent<CapsuleCollider2D>();

        SetCollider();
        BeginLiveCounter();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Enemy>(out Enemy enemy))
        {
            enemy.TakeDamage(_damage);
            Destroy(gameObject);
        }
    }

    private void BeginLiveCounter()
    {
        if (_liveCounter != null)
            StopCoroutine(_liveCounter);

        _liveCounter = StartCoroutine(LiveCounter());
    }

    private void SetCollider()
    {
        float xSize = 0.3f;
        float ySize = 1.1f;

        _collider.size.Set(xSize, ySize);
    }

    private IEnumerator LiveCounter()
    {
        float seconds = 0.5f;
        var waitTime = new WaitForSeconds(seconds);
        bool isWorked = false;

        while (isWorked == false)
        {
            isWorked = true;
            yield return waitTime;
        }

        if (isWorked)
        {
            Destroy(gameObject);
            yield break;
        }
    }
}
