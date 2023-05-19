using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _health;
    [SerializeField] private Player _target;

    private UnityAction _onTakenDamage;
    private UnityAction _onDied;

    private Coroutine _destroyer;

    public Player Target => _target;

    public event UnityAction TakenDamage
    {
        add => _onTakenDamage += value;
        remove => _onTakenDamage -= value;
    }

    public event UnityAction Died
    {
        add => _onDied += value;
        remove => _onDied -= value;
    }

    public void TakeDamage(float damage)
    {
        _health -= damage;
        _onTakenDamage.Invoke();

        if (_health <= 0)
        {
            _onDied.Invoke();
            BeginDestroy();
        }
    }

    private void BeginDestroy()
    {
        if (_destroyer != null)
            StopCoroutine(_destroyer);

        _destroyer = StartCoroutine(Destroyer());
    }

    private IEnumerator Destroyer()
    {
        float second = 1.0f;
        var waitTime = new WaitForSeconds(second);
        bool isSkeppedTime = false;

        while (isSkeppedTime == false)
        {
            isSkeppedTime = true;
            yield return waitTime;
        }

        if(isSkeppedTime)
        {
            Destroy(gameObject);
            yield break;
        }
    }
}
