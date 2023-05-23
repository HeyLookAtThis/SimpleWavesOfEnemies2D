using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Attack : MonoBehaviour
{
    [SerializeField] private float _damage;
    [SerializeField] private float _lifeTime;

    private Coroutine _liveCounter;

    protected void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Character>(out Character character))
            character.TakeDamage(_damage);
    }

    protected void BeginDestroyer()
    {
        if (_liveCounter != null)
            StopCoroutine(Destroyer());

        _liveCounter = StartCoroutine(Destroyer());
    }

    protected IEnumerator Destroyer()
    {
        var waitTime = new WaitForSeconds(_lifeTime);
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
