using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]

public class DestructionZone : MonoBehaviour
{
    [SerializeField] private float _damage;

    private Coroutine _liveCounter;
    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void Run()
    {
        _animator.Play(ACDirectionZone.State.Hit);
        BeginDestroyer();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Enemy>(out Enemy enemy))
            enemy.TakeDamage(_damage);
    }

    private void BeginDestroyer()
    {
        if (_liveCounter != null)
            StopCoroutine(Destroyer());

        _liveCounter = StartCoroutine(Destroyer());
    }

    private IEnumerator Destroyer()
    {
        float seconds = 1f;
        var waitTime = new WaitForSeconds(seconds);
        bool isWorked = false;

        while(isWorked == false)
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
